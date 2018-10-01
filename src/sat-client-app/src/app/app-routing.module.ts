import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { AuthGuardService as AuthGuard } from './services/auth-guard.service';





const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard], data: { title: 'Home' } },
  { path: 'login', component: LoginComponent, data: { title: 'Login' } },
  // { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard], data: { title: 'Customers' } },
  // { path: 'products', component: ProductsComponent, canActivate: [AuthGuard], data: { title: 'Products' } },
  // { path: 'orders', component: OrdersComponent, canActivate: [AuthGuard], data: { title: 'Orders' } },
  // { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard], data: { title: 'Settings' } },
  // { path: 'about', component: AboutComponent, data: { title: 'About Us' } },
  { path: 'home', redirectTo: '/', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent, data: { title: 'Page Not Found' } }
];




@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
