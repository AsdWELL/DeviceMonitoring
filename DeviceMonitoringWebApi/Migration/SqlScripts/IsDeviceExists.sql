SELECT EXISTS (
	SELECT 1 FROM "DeviceSessions"
	WHERE "DeviceId" = @DeviceId
);