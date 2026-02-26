import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, Observable, throwError } from "rxjs";
import { DeviceInfo, DeviceSession } from "../models/device.models";
import { environment } from "../../environment/environment";

@Injectable({
    providedIn: 'root'
})
export class DeviceSessionService {
    private readonly http = inject(HttpClient);
    private readonly apiUrl = `${environment.apiUrl}/devicesession`;

    private handleError(error: HttpErrorResponse): Observable<never> {
        console.error(error.message);

        return throwError(() => new Error(error.message));
    }

    getAllDevices(): Observable<DeviceInfo[]> {
        return this.http
            .get<DeviceInfo[]>(`${this.apiUrl}/devices`)
            .pipe(catchError(this.handleError));
    }

    getDeviceSessions(deviceId: string): Observable<DeviceSession[]> {
        return this.http
            .get<DeviceSession[]>(`${this.apiUrl}/${deviceId}`)
            .pipe(catchError(this.handleError));
    }
}