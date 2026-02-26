import { CommonModule } from "@angular/common";
import { Component, inject, OnInit } from "@angular/core";
import { RouterLink } from "@angular/router";
import { LoaderComponent } from "../loader/loader.component";
import { DeviceSessionService } from "../../services/device-session.service";
import { DeviceInfo } from "../../models/device.models";

@Component({
    selector: 'app-devices-list',
    standalone: true,
    imports: [CommonModule, RouterLink, LoaderComponent],
    templateUrl: './devices-list.component.html',
    styleUrl: './devices-list.component.less'
})
export class DevicesListComponent implements OnInit {
    private readonly deviceService = inject(DeviceSessionService);

    devices: DeviceInfo[] = [];
    isLoading = true;
    error: string | null = null;

    ngOnInit(): void {
        this.loadDevices();
    }

    loadDevices(): void {
        this.isLoading = true;
        this.error = null;

        this.deviceService.getAllDevices().subscribe({
            next: (data) => {
                this.devices = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.error = err.message;
                this.isLoading = false;
            }
        });
    }

    trackDeviceId(index: number, device: DeviceInfo): string {
        return device.deviceId;
    }

    formatDate(dateString: string): string {
        return new Date(dateString).toLocaleString('ru-RU');
    }
}