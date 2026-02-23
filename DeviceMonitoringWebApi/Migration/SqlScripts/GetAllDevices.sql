SELECT DISTINCT ON ("DeviceId")
    "Id", "DeviceId", "Name", "StartTime", "EndTime", "Version"
FROM "DeviceSessions"
ORDER BY "DeviceId", "EndTime" DESC;