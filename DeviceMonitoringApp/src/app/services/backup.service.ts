import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../environment/environment";
import { catchError, map, Observable, throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BackupService {
    private readonly http = inject(HttpClient);
    private readonly apiUrl = `${environment.apiUrl}/backup`;

    private handleError(error: HttpErrorResponse): Observable<never> {
        console.error(error.message);

        return throwError(() => new Error(error.message));
    }

    getBackups(): Observable<string[]> {
        return this.http
            .get<string[]>(this.apiUrl)
            .pipe(catchError(this.handleError));
    }

    createBackup(): Observable<string> {
        return this.http
            .post<{ fileName: string }>(this.apiUrl, {})
            .pipe(
                map(response => response.fileName),
                catchError(this.handleError));
    }

    downloadBackup(fileName: string): Observable<Blob> {
        return this.http
            .get(`${this.apiUrl}/download/${fileName}`, { responseType: 'blob' })
            .pipe(catchError(this.handleError));
    }
}