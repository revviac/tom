## Resources and the user model
TOM defines the following resources:
- Tag servers
- Tags
- Objects and keys

Tag servers and tags may be created, deleted and edited only by a privileged user that
has the `server_manager` role. For all other users the tag information is read-only.

Objects and keys can be created by any user. This user will have an exclusive control
over the resource. The only users that can edit or delete other users' objects (keys)
are the administrators of the system. If a key is added or deleted from the object,
the user must have that object as their managed resource (or be the administrator of the system).

Similarly, when the object is read or written to, the person must have that object as
their managed resource.

## User scenarios
1. As a **user**, I want to register an object schema so I can retrieve the object snapshot later.
2. As a **user**, I want to add a new key to the object schema so I can read a new property I require.
3. As a **user**, I want to delete an existing key from the object schema, because I no longer require it.
4. As a **user**, I want to delete an existing object, because I no longer use it.
5. As a **user**, I want to read the object snapshot, so that I can use it in downstream operations (e.g. calculations)
6. As a **user**, I want to update the object snapshot, so that it is written to the connected IoT device.
7. As a **user**, I want to read the value of a specific readable key of the object, so that I may use it in downstream operations.
8. As a **user**, I want to update the value of a writeable key of the object, so that it is written to the connected IoT device.
9. As a **user**, I want to retrieve the raw history of values of a specific object key, so that I can use it in downstream operations.
10. As a **user**, I want to retrieve a preprocessed history of values in the specific time range, so that it can be used in downstream operations. The preprocessing steps may include:
    - Filling null values with interpolated values, LOCF (last observation carried forward), the timeseries mean, some value, etc.
    - Dropping all null values
    - Resample the timeseries, aggregating data with min/max/avg aggregation functions in case of downsampling (e.g. 1 minute to 10 seconds) or interpolating in case of upsampling.
    - Applying a moving average or weighted moving average filter to the timeseries.
11. As a **user**, I want to retrieve a preprocessed latest history of values with the same preprocessing steps as described above.
12. As a **server manager**, I want to create a new server, so that other users may use it.
13. As a **server manager**, I want to register tags from a tag server, so that other users may use it.
14. As a **server manager**, I want to delete a tag from the tag server, because it is no longer accessible.
15. As a **server manager**, I want to change the tag type of a tag in a tag server, because it has been configured incorrectly.
16. As a **server manager**, I want to change the tag address of a tag in a tag server, because it has been configured incorrectly.
17. As a **server manager**, I want to change the address of the tag server, because it has been moved or configured incorrectly.
18. As a **server manager**, I want to delete a tag server, because it is no longer accessible.
19. As an **administrator**, I want to remove an object of another user, because it causes a system error.
20. As an **administrator**, I want to edit an object of another user, because it causes a system error.
21. As an **administrator**, I want to remove a key in an object of another user, because it causes a system error.
22. As an **administrator**, I want to edit a key in an object of another user, because it causes a system error.

## Abuse cases
These cases must always fail.
1. As a **user**, I want to delete another user's resource, so that they lose access to the resource.
2. As a **user**, I want to edit another user's resource, so that they receive or update incorrect data.
3. As a **user**, I want to delete a tag server or a tag another user relies on, so that their system will stop functioning properly.
4. As a **user**, I want to edit a tag another user uses, so that their system will stop functioning properly.
5. As a **user**, I want to read a value of a write-only key in order to gain an unsanctioned access to the system information.
6. As a **user**, I want to write a value to a read-only key in order to break the system.

Additionally, user may cause a DoS attack, either intentional or not. This can be done by requesting the object a lot
over a short period of time. The DoS can't be completely solved at the server level, but its impacts may be mitigated a little:
1. If the object is requested a lot over a short period of time (e.g. 1 second), the first request may be cached with a small TTL.
This will prevent multiple requests of the same data to the tag server, which may not handle as many requests as the ASP.NET server.
2. If the history is requested with a very small period (e.g. 1 second) over a very long period of time (e.g. 1 year) without
specifying the maximum number of points, it may cause a lot of stress on the database or the server trying to serialize the
collection of points to send to user. This may be solved by specifying the maximal number of points in the history to be some
sufficiently big number (e.g. 100,000 points).

## Corner cases
1. As a **user**, I want to create an object with the same id as one that another user owns:
   - Users shouldn't know about the resources of another users, so two objects with the same id may exist as long as
     the user id is different.
2. As a **user**, I want to add a key with an already existing name to the object:
   - One object can't have duplicate key names, so this is an exceptional case which should result in an error.
3. As a **user**, I want to remove the last key from the object:
   - An object must have at least one key at all times. If the user wants to remove the only key of an object,
     this should result in the deletion of the object. Ideally, they should be notified about this behavior in the
     graphical UI.

## Exceptional cases
(not a full list)
1. Server does not exist
2. Server does not respond
3. Error during server communication
4. Tag does not exist
5. Writing to a read-only tag
6. Reading a write-only tag
7. Writing a value to the tag of an incompatible type
8. Object key with given name does not exist
9. Reading a write-only key
10. Writing to a read-only key
11. Writing a value to the key of an incompatible type
12. Object does not exist
13. User not authorized