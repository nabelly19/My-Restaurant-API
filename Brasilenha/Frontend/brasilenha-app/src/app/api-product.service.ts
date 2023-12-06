// import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClientData } from './client-data';
import { ApiClientService } from './api-client.service';
import { PoductData } from './product-data';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiProductService {
  constructor(private http: ApiClientService) {}

  register(data: PoductData) {
    this.http.post('produto/registrar', data).subscribe({
      next: (response) => {
        console.log(response);
      },
    });
  }
  uploadImage(image: FormData): Observable<any> {
    return this.http.post('produto/imagem', image);
  }
}
