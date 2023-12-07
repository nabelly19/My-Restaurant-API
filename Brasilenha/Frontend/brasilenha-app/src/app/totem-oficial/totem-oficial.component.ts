import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardsComponent } from '../cards/cards.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiShopListService } from '../api-shop-list.service';
import { ApiProductService } from '../api-product.service';

@Component({
  selector: 'app-totem-oficial',
  standalone: true,
  imports: [CommonModule, CardsComponent ],
  templateUrl: './totem-oficial.component.html',
  styleUrl: './totem-oficial.component.css'
})
export class TotemOficialComponent {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private servico: ApiProductService,
    
    
  ) {this.getProduct()}

  produtos: any = []
  getProduct(){
    this.servico.getAll().subscribe({
      next: (res) => {
        console.log(res)
        this.produtos = res
      }
  })
  }

}
