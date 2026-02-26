import { CommonModule } from "@angular/common";
import { Component, inject, OnInit } from "@angular/core";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { LoaderComponent } from "../loader/loader.component";
import { DeviceSessionService } from "../../services/device-session.service";
import { DeviceSession } from "../../models/device.models";

@Component({
    selector: 'app-device-detail',
    standalone: true,
    imports: [CommonModule, RouterLink, LoaderComponent],
    templateUrl: './device-detail.component.html',
    styleUrl: './device-detail.component.less'
})
export class DeviceDetailComponent implements OnInit {
    private readonly deviceService = inject(DeviceSessionService);
    private readonly route = inject(ActivatedRoute);

    deviceId = '';
    sessions: DeviceSession[] = [];
    isLoading = true;
    error: string | null = null;

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('deviceId');
        if (id) {
            this.deviceId = id;
            this.loadSessions();
        } else {
            this.error = 'ID не указан';
            this.isLoading = false;
        }
    }

    loadSessions(): void {
        this.isLoading = true;
        this.error = null;

        this.deviceService.getDeviceSessions(this.deviceId).subscribe({
            next: (data) => {
                this.sessions = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.error = err.message;
                this.isLoading = false;
            }
        });
    }

    trackSessionId(index: number, session: DeviceSession): string {
        return session.id;
    }

    formatDate(dateString: string): string {
        return new Date(dateString).toLocaleString('ru-RU');
    }

    getSessionDuration(start: string, end: string): string {
        const diff = new Date(end).getTime() - new Date(start).getTime();

        const diffMinutes = Math.floor(diff / 60000);
        const hours = Math.floor(diffMinutes / 60);
        const minutes = diffMinutes % 60;

        return `${hours}ч ${minutes % 60}м`;
    }
}