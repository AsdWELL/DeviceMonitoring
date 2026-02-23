SELECT id, device_id, name, start_time, end_time, version
FROM device_sessions
WHERE device_id = @DeviceId
ORDER BY start_time;