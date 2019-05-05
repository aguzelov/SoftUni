import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ArticleComponent } from './article/article.component';
import { ArticlesComponent } from './articles/articles.component';
import { ArticleService } from './articles/articlesService';

@NgModule({
	declarations: [ AppComponent, ArticleComponent, ArticlesComponent ],
	imports: [ BrowserModule, AppRoutingModule ],
	providers: [ ArticleService ],
	bootstrap: [ AppComponent ]
})
export class AppModule {}
