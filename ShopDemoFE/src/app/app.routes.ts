import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
  { path: '', component: LoginComponent }, 

  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      { path: 'client', loadComponent: () => import('./admin/client/client.component').then(m => m.ClientComponent) },
      { path: 'item', loadComponent: () => import('./admin/items/items.component').then(m => m.ItemsComponent) },
      { path: 'shop', loadComponent: () => import('./admin/shop/shop.component').then(m => m.ShopComponent) }, 
      { path: '', redirectTo: 'client', pathMatch: 'full' }  
    ]
  },

  { path: '**', redirectTo: '' }  
];
