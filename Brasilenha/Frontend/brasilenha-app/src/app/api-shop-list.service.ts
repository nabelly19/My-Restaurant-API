import { Injectable } from '@angular/core';
import { PoductData } from './product-data';
import { ApiProductService } from './api-product.service';
import { ApiClientService } from './api-client.service';

@Injectable({
    providedIn: 'root',
  })
  export class ApiShopListService 
  {
     carrinho: PoductData[] = []

     iniciarCarrinho() 
     {
        let abrircarrinho: PoductData[] = [];
        localStorage.setItem('Carrinho', JSON.stringify(abrircarrinho));
     }

     adicionarAoCarrinho(product: PoductData)
     {
        this.carrinho.push(product);
        localStorage.setItem('carrinho', JSON.stringify(this.carrinho));
     }

     pegarCarrinho()
     {
        var armazenamentoCarrinho = localStorage.getItem('Carrinho');
        if(armazenamentoCarrinho === null)
            return null

        let data = JSON.parse(armazenamentoCarrinho);
        return data;
     }

     pegarPrecoPeloNome(Nome: string): number {
        var lista = localStorage.getItem('lista');

        if (lista === null){
            return 0;
        }

        let preco: number = 0;

        let data: PoductData[] = JSON.parse(lista);
        data.forEach((element) => {
            if (element.nomeProduto == Nome) preco = element.valor;
        });
        return preco;
     }

      constructor(private http: ApiClientService) {}

      iniciarItens()
      {
        var produto = this.http.get("produto");
        return produto;
      }
     
  }