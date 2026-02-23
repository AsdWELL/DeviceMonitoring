SELECT DISTINCT ON (device_id)
    device_id, name, start_time, end_time, version
FROM device_sessions
ORDER BY device_id, end_time DESC;