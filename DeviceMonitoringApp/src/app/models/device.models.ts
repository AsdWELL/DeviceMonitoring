export interface CreateDeviceSessionRequest {
    deviceId: string;
    name: string;
    startTime: string;
    endTime: string;
    version: string;
}

export interface DeviceSession {
    id: string;
    deviceId: string;
    name: string;
    startTime: string;
    endTime: string;
    version: string;
}

export interface DeviceInfo {
    deviceId: string;
    name: string;
    lastSession: string;
}

export interface ApiError {
    statusCode: number;
    message: string;
}