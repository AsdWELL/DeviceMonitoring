SELECT "Id", "DeviceId", "Name", "StartTime", "EndTime", "Version"
FROM "DeviceSessions"
WHERE "DeviceId" = @DeviceId
ORDER BY "StartTime";