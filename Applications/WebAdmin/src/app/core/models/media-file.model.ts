import { SharedUser } from './shared-user.model';

export class MediaFile {
    id: number;
    url: string;
    isVideo: boolean;
    isTemp: boolean;
    sharedWith: SharedUser[] = [];
}
