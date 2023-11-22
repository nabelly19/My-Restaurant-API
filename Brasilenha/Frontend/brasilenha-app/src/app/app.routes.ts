import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { TotemComponent } from './totem/totem.component';

export const routes: Routes = [
    {path: "", component: LoginComponent},
    {path: "Totem", component: TotemComponent},
];
