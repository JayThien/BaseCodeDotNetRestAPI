import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { map } from 'rxjs/operators';
import { UploadService } from 'src/app/core/service/api/uploader.service';

export enum UploadState {
  Init,
  Loading,
  Loaded,
}

@Component({
  selector: 'app-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.scss']
})
export class UploaderComponent implements OnInit, OnChanges {
  @Input() value!: string;
  @Input() size!: number;
  @Input() isAvatar!: boolean;
  @Output() uploaded: EventEmitter<string> = new EventEmitter<string>();

  uploadState = UploadState.Init;
  UploadState = UploadState;
  uploadUrl!: string;

  constructor(
    private uploadService: UploadService
  ) {

  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.value?.currentValue) {
      this.uploadState = UploadState.Loaded;
      this.uploadUrl = this.value;
    }
  }

  get backgroundImage(): string {
    let url = '';
    switch (this.uploadState) {
      case UploadState.Init:
        url = '../../../../assets/images/common/outline_camera_enhance.png';
        break;
      case UploadState.Loading:
        url = '../../../../assets/images/common/loading.gif';
        break;
      case UploadState.Loaded:
        url = this.uploadUrl;
        break;
    }
    return `url('${url}')`;
  }

  ngOnInit(): void {

  }

  receiveFromDropzone(files: FileList): void {
    if (this.uploadState === UploadState.Loading) {
      return;
    }
    this.uploadState = UploadState.Init;
    if (files.length > 1 || files.length < 0) {
      alert('Please only drag your desired profile photo.');
      return;
    }
    this.startUpload(files[0]);
  }

  receiveFromInput(target: any): void {
    if (this.uploadState === UploadState.Loading) {
      return;
    }
    this.uploadState = UploadState.Init;
    // tslint:disable-next-line: no-non-null-assertion
    const files = (target as HTMLInputElement).files!;
    if (files.length > 1 || files.length < 0) {
      alert('Please only drag your desired profile photo.');
      return;
    }
    this.startUpload(files[0]);
  }

  startUpload(file: File): void {
    if (file) {
      this.uploadService.uploadToServer(file)
        .pipe(
          map((event) => {
            switch (event.type) {
              case HttpEventType.UploadProgress:
                this.uploadState = UploadState.Loading;
                return { status: 'progress', message: 'uploading' };
              case HttpEventType.Response:
                this.uploadState = UploadState.Loaded;
                return event.body;
              default:
                return `Unhandled event: ${event.type}`;
            }
          })
        ).subscribe(
          result => {
            if (result.uploadedPath) {
              this.uploadUrl = result.uploadedPath;
              this.uploaded.emit(this.uploadUrl);
            }
          }, error => {
            this.uploadState = UploadState.Init;
          }
        );
    }

  }
}
