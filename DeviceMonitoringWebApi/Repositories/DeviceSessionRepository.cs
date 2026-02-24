using Dapper;
using DeviceMonitoringWebApi.Entities;
using DeviceMonitoringWebApi.Migration;
using DeviceMonitoringWebApi.Repositories.Interfaces;
using System.Data;

namespace DeviceMonitoringWebApi.Repositories
{
    public class DeviceSessionRepository(IDbConnection dbConnection) : IDeviceSessionRepository
    {
        public async Task<int> AddDeviceSession(DeviceSession deviceSession)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<int>(Sql.InsertDeviceSession, deviceSession);
        }

        public async Task<List<DeviceSession>> GetAllDevices()
        {
            return [.. await dbConnection.QueryAsync<DeviceSession>(Sql.GetAllDevices)];
        }

        public async Task<List<DeviceSession>> GetAllSessions()
        {
            return [.. await dbConnection.QueryAsync<DeviceSession>(Sql.GetAllSessions)];
        }

        public async Task<List<DeviceSession>> GetDeviceSessionsByDeviceId(string deviceId)
        {
            return [.. await dbConnection.QueryAsync<DeviceSession>(Sql.GetSessionsByDeviceId,
                new { DeviceId = deviceId })];
        }

        public async Task<bool> IsDeviceExists(string deviceId)
        {
            return await dbConnection.ExecuteScalarAsync<bool>(Sql.IsDeviceExists,
                new { DeviceId = deviceId });
        }
    }
}
