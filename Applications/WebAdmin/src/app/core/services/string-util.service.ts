import { Injectable } from '@angular/core';
import { element } from 'protractor';

@Injectable({ providedIn: 'root' })
export class StringUtil {
    convertStringToList(input: string): string[] {
        if (input) {
            const datas = input.split('-');
            const result = [];
            datas.forEach(e => {
                if (e !== '') {
                    result.push(`-${e}`);
                }
            });
            return result;
        }
        return [];
    }
}
