import { AuthGuardService } from './services/auth-guard.service';
import { JournalEditorComponent } from './journal-editor/journal-editor.component';
import { JournalsListComponent } from './journals-list/journals-list.component';
import { UserAuthenticationComponent } from './user-authentication/user-authentication.component';
import { HeaderComponent } from './header/header.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: HeaderComponent,
  },
  {
    path: 'user-check',
    component: UserAuthenticationComponent,
  },
  {
    path: 'journals',
    component: JournalsListComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'journal',
    component: JournalEditorComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'journal/:id',
    component: JournalEditorComponent,
    canActivate: [AuthGuardService],
  },
  // {
  //   path: 'user-check',
  //   component: UserAuthenticationComponent,
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
