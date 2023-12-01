import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { TotemComponent } from './totem/totem.component';
import { TotemOficialComponent } from './totem-oficial/totem-oficial.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { CardapioComponent } from './cardapio/cardapio.component';
import { TotemOficialBannerInicialComponent } from './totem-oficial-banner-inicial/totem-oficial-banner-inicial.component';
import { CardsComponent } from './cards/cards.component';
import { ClientAppStoreComponent } from './client-app-store/client-app-store.component';
import { ClientAppStorePromotionsComponent } from './client-app-store-promotions/client-app-store-promotions.component';

export const routes: Routes = [
    {path: "", component: LoginComponent},
    {path: "Totem", component: TotemComponent},
    {path: "TotemOficial", component: TotemOficialComponent},
    {path: "Pedidos", component: PedidosComponent},
    {path: "Cardapio", component: CardapioComponent},
    {path: "HomeTotem", component: TotemOficialBannerInicialComponent},
    {path: "Cards", component: CardsComponent},
    {path: "ClientApp", component: ClientAppStoreComponent},
    {path: "ClientAppPromotions", component: ClientAppStorePromotionsComponent}
];
