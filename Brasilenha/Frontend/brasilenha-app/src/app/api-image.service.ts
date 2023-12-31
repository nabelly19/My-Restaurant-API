import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { defaultEquals } from '@angular/core/primitives/signals';

@Injectable({
  providedIn: 'root'
})
export class ApiImageService {
  backend = 'http://localhost:5146/'

  constructor(private http: HttpClient) { }

  get(url: string) {
    return this.http
      .get(this.backend + url)
  }

  post(url: string, obj: any) {
    return this.http
      .post(this.backend + url, obj)
  }
}
