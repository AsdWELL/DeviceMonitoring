import { Component } from "@angular/core";
import { RouterLink, RouterLinkActive, RouterOutlet } from "@angular/router";
import 'zone.js';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive],
    templateUrl: './app.component.html',
    styleUrl: './app.component.less'
})
export class AppComponent {
    title = 'DeviceMonitoring';
}