INSERT INTO "DeviceSessions" ("DeviceId", "Name", "StartTime", "EndTime", "Version")
VALUES
	(@DeviceId, @Name, @StartTime, @EndTime, @Version)
RETURNING "Id";