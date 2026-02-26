import { CommonModule } from "@angular/common";
import { Component, inject, OnInit } from "@angular/core";
import { RouterLink } from "@angular/router";
import { LoaderComponent } from "../loader/loader.component";
import { BackupService } from "../../services/backup.service";

@Component({
    selector: 'app-backups',
    standalone: true,
    imports: [CommonModule, RouterLink, LoaderComponent],
    templateUrl: './backups.component.html',
    styleUrl: './backups.component.less'
})
export class BackupComponent implements OnInit {
    private readonly backupService = inject(BackupService);

    backups: string[] = [];
    isLoading = true;
    isCreating = false;
    error: string | null = null;
    successMessage: string | null = null;

    ngOnInit(): void {
        this.loadBackups();
    }

    loadBackups(): void {
        this.isLoading = true;
        this.error = null;

        this.backupService.getBackups().subscribe({
            next: (data) => {
                this.backups = data;
                this.isLoading = false;
            },
            error: (err) => {
                this.error = err.message;
                this.isLoading = false;
            }
        });
    }

    createBackup(): void {
        this.isCreating = true;
        this.successMessage = null;
        this.error = null;

        this.backupService.createBackup().subscribe({
            next: (fileName) => {
                this.successMessage = `Бекап ${fileName} создан`;
                this.isCreating = false;
                this.loadBackups();
            },
            error: (err) => {
                this.error = err.message;
                this.isCreating = false;
            }
        });
    }

    downloadBackup(fileName: string): void {
        this.backupService.downloadBackup(fileName).subscribe({
            next: (blob) => {
                const url = window.URL.createObjectURL(blob);
                const link = document.createElement('a');
                link.href = url;
                link.download = fileName;
                link.click();
                window.URL.revokeObjectURL(url);
            },
            error: (err) => {
                this.error = `Ошибка скачивания: ${err.message}`;
            }
        });
    }

    trackFileName(index: number, fileName: string): string {
        return fileName;
    }
}