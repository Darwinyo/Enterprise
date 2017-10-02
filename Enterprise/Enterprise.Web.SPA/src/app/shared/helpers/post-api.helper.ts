import { Injectable } from '@angular/core';
@Injectable()
export class PostApiHelper {
    concatDoubleQuote(plainStr: string): string {
        return '"' + plainStr + '"';
    }
}
