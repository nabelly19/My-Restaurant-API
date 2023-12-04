import { Injectable } from '@angular/core';
import { ClientData } from './client-data';
import { ApiClientService } from './api-client.service';

import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  constructor(private http: ApiClientService) { }

  register(data: ClientData)
  {
    console.log(data)
    // this.http.post('usuario/register', data)
    //   .subscribe(response => console.log(response))
    this.http.post('usuario/registrar', data)
    .pipe(
      catchError(error => {
        console.error('Error:', error);
        return throwError(error);
      })
    )
    .subscribe(response => console.log(response));
  }

  login(data: ClientData, callback: any)
  {
    this.http.post('usuario/login', data)
      .subscribe({
        next: response => { callback(response) },
        error: error => { callback(null) }
      })
  }
}