import { Injectable } from '@angular/core';
import { ClientData } from './client-data';
import { ApiClientService } from './api-client.service';
import { PoductData } from './product-data';
import { CupomData } from './cupom-data';

@Injectable ({
    providedIn: 'root'
})
export class CupomService {
    constructor(private http: ApiClientService) {}

    register(data: CupomData)
    {
        this.http.post('cupom/registrar', data)
            .subscribe(response => console.log(response))
    }

    
}