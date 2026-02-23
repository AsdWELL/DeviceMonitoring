SELECT EXISTS (
	SELECT 1 FROM device_sessions
	WHERE device_id = @DeviceId
);