INSERT INTO device_sessions (device_id, name, start_time, end_time, version)
VALUES
	(@DeviceId, @Name, @StartTime, @EndTime, @Version)
RETURNING id;