import { Routes } from "@angular/router";
import { DevicesListComponent } from "./components/devices-list/devices-list.component";
import { DeviceDetailComponent } from "./components/device-details/device-detail.component";
import { BackupComponent } from "./components/session-backups/backups.component";

export const routes: Routes = [
    { path: '', redirectTo: 'devices', pathMatch: 'full' },
    { path: 'devices', component: DevicesListComponent },
    { path: 'device/:deviceId', component: DeviceDetailComponent },
    { path: 'backups', component: BackupComponent },
    { path: '**', redirectTo: 'devices' }
];