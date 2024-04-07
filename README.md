# TOM
TOM (Tag Object Model) is a prototype of a service that allows the user to aggregate information from multiple IoT devices into an object using a schema. The deployment target of TOM is an ASP.NET web server.

## Motivation
Big IoT systems may have a lot of devices that serve real-time data. Logically, these devices may be grouped together
to represent a "snapshot" of some object of interest.
In the terminology of TOM, these objects serve data via tags over some protocol (e.g. OPC UA).

If the system is comprised of many devices that serve data about a single object of interest, each subsequent
service that wants to request this information (and potentially modify it) will need to implement their own connection
to the server. This may cause latency if the server is run on a microcontroller and can't handle a lot of requests.

Moreover, if several services use information about the same object, they'll have to synchronize what tags
they use to get information about the object. If the tag name is changed on the server (a situation that may occur
more often than one would hope...) this change must be correctly processed by all the services.

The final problem is requesting the history of values about some tag. Without a special interface (like OPC HDA)
this will need to be done manually. Implementing some of the common operations on time series may be a difficult task.
For example, many algorithms of machine learning that work with time series assume the time series data to be
equally spaced. This means that the historical data from device should be resampled (in case there has been a lost data point
or the period of the time series is inconsistent). Resampling may be too difficult and annoying to implement on the client side
and ideally it should be implemented as close to the database as possible.

TOM aims to solve these problems by providing a single point of reference about the tags and historical information.
Instead of keeping tags, TOM keeps information about *objects* - an aggregate of keys, each key being connected to a tag.
When an object (or its keys) is requested, the connected tags are read - either from the cache if caching is enabled,
or from the server if no values are stored in cache or caching is disabled. Additionally,
when the object (or the key) is updated, this update is proxied to the server.

Requesting the historical information about a tag is equivalent to requesting the history of a key.
This history is being stored in a time series database. Operations like resampling, null handling
and calculating the moving average are executed directly in the database.

## Tags
Tags are used to access device information served by some server, which will be called the tag
server from now on. They represent a unique identifier with information about:
- the server that the tag is served from;
- address on the server that can be used to retrieve/write data;
- whether the tag is read-only, write-only or both;
- the tag type (if the written value is not of a valid type, the write will fail).

Additionally, the tags may be created as *stubs*. A stub tag has an empty server/address values
and will store the data in the cache (making it potentially volatile). Stub tags are used to create objects
first and connect to the tag server later. Moreover, stub tags can't store history.

## Objects and keys
TOM interface is tied to the notion of objects, which are aggregates of keys. A key is a tag that has
a valid property name. This name must be unique to the object. For example, imagine a typical PID regulator
that has tags `PID.PV`, `PID.SV` and `PID.MV` defined. An equivalent object would have the following schema:
```json5
[
    {
        "name": "pv",
        "tag": {
            "server": "opc.tcp://...",
            "address": "PID.PV",
            "mode": "readonly", // Will fail on write
            "type": "double" // Accepts double/float values
        }
    },
    {
        "name": "sv",
        "tag": {
            "server": "opc.tcp://...",
            "address": "PID.SV",
            "mode": "readwrite", // Can be read or written to
            "type": "double"
        }
    },
    {
        "name": "mv",
        "tag": {
            "server": "opc.tcp://...",
            "address": "PID.MV",
            "mode": "readonly",
            "type": "double"
        }
    }
]
```

When reading the snapshot of a PID regulator, this will produce an object like:
```json
{
    "pv": 10.37,
    "sv": 10.3,
    "mv": -0.8
}
```

To read the tag history, you may request the history of a certain object key. If you connect to the
server via the REST API, you may use a handle like
```
GET /api/objects/.../pv/latest_history?bucket_size=30s&max_history_length=1h&num_points=60&order=NewestFirst
```
to get a 30 seconds history of up to 60 points for the last hour, with newest elements first. A response may look like:
```json5
[
    10.37,
    10.28,
    10.18,
    // 56 more points
    9.31
]
```

## Development
This project uses [Husky.NET](https://alirezanet.github.io/Husky.Net/) to enable pre-commit hooks.
Husky comes with the solution tool manifest, you can install pre-commit hooks using `dotnet husky install`.