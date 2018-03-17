<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
	<style>
	@page{
  size: letter portrait;
  margin: 0;
}

*{
  box-sizing: border-box;
}

:root{
  --page-width: 8.5in;
  --page-height: 11in;
  --main-width: 6.4in;
  --sidebar-width: calc(var(--page-width) - var(--main-width));
  --decorator-horizontal-margin: 0.2in;

  --sidebar-horizontal-padding: 0.2in;

  /* XXX: using px for very good precision control */
  --decorator-outer-offset-top: 10px;
  --decorator-outer-offset-left: -5.5px;
  --decorator-border-width: 1px;
  --decorator-outer-dim: 9px;
  --decorator-border: 1px solid #ccc;

  --row-blocks-padding-top: 5pt;
  --date-block-width: 0.6in;

  --main-blocks-title-icon-offset-left: -19pt;
}

body{
  width: var(--page-width);
  height: var(--page-height);
  margin: 0;
  font-family: "Open Sans", sans-serif; 
  font-weight: 300;
  line-height: 1.3;
  color: #444;
  hyphens: auto;
}

h1, h2, h3{
  margin: 0;
  color: #000;
}

li{
  list-style-type: none;
}

#main{
  float: left;
  width: var(--main-width);
  padding: 0.25in 0.25in 0 0.25in;
  font-size: 7pt;
}

#sidebar{
  float: right;
  position: relative; /* for disclaimer */
  width: var(--sidebar-width);
  height: 200%;
  padding: 0.25in var(--sidebar-horizontal-padding);
  background-color: #f2f2f2;
  font-size: 8.5pt;
}

/* main */

/** big title **/
#title, h1, h2{
  text-transform: uppercase;
}

#title{
  position: relative;
  left: 0.55in;
  margin-bottom: 0.3in;
  line-height: 1.2;
}

#title h1{
  font-weight: 300;
  font-size: 18pt;
  line-height: 1.5;
}

#title h1 strong{
  margin: auto 2pt auto 4pt;
  font-weight: 600;
}

.subtitle{
  font-size: 8pt;
}

/*** categorial blocks ***/

.main-block{
  margin-top: 0.1in;
}

#main h2{
  position: relative;
  top: var(--row-blocks-padding-top);
  /* XXX: 0.5px for aligning fx printing */
  left: calc((var(--date-block-width) + var(--decorator-horizontal-margin)));
  font-weight: 400;
  font-size: 11pt;
  color: #555;
}

#main h2 > i{
  /* use absolute position to prevent icon's width from misaligning title */
  /* assigning a fixed width here is no better due to needing to align decorator
     line too */
  position: absolute;
  left: var(--main-blocks-title-icon-offset-left);
  z-index: 1; /* over decorator line */
  color: #444;
}

#main h2::after{ /* extends the decorator line */
  height: calc(var(--row-blocks-padding-top) * 2);
  position: relative;
  top: calc(-1 * var(--row-blocks-padding-top));
  /* XXX: 0.5px for aligning fx printing */
  left: calc(-1 * var(--decorator-horizontal-margin));
  display: block;
  border-left: var(--decorator-border);
  z-index: 0;
  line-height: 0;
  font-size: 0;
  content: ' ';
}

/**** minor tweaks on the icon fonts ****/
#main h2 > .fa-graduation-cap{
  left: calc(var(--main-blocks-title-icon-offset-left) - 2pt);
  top: 2pt;
}

#main h2 > .fa-suitcase{
  top: 1pt;
}

#main h2 > .fa-folder-open{
  top: 1.5pt;
}

/**** individual row blocks (date - decorator - details) ****/

.blocks{
  display: flex;
  flex-flow: row nowrap;
}

.blocks > div{
  padding-top: var(--row-blocks-padding-top);
}

.date{
  flex: 0 0 var(--date-block-width);
  padding-top: calc(var(--row-blocks-padding-top) + 2.5pt) !important;
  padding-right: var(--decorator-horizontal-margin);
  font-size: 7pt;
  text-align: right;
  line-height: 1;
}

.date span{
  display: block;
}

.date span:nth-child(2)::before{
  position: relative;
  top: 1pt;
  right: 5.5pt;
  display: block;
  height: 10pt;
  content: '|';
}

.decorator{
  flex: 0 0 0;
  position: relative;
  width: 2pt;
  min-height: 100%;
  border-left: var(--decorator-border);
}

/*
 * XXX: Use two filled circles to achieve the circle-with-white-border effect.
 * The normal technique of only using one pseudo element and
 * border: 1px solid white; style makes firefox erroneously either:
 * 1) overflows the grayshade background (if no background-clip is set), or
 * 2) shows decorator line which should've been masked by the white border
 *
 */

.decorator::before{
  position: absolute;
  top: var(--decorator-outer-offset-top);
  left: var(--decorator-outer-offset-left);
  content: ' ';
  display: block;
  width: var(--decorator-outer-dim);
  height: var(--decorator-outer-dim);
  border-radius: calc(var(--decorator-outer-dim) / 2);
  background-color: #fff;
}

.decorator::after{
  position: absolute;
  top: calc(var(--decorator-outer-offset-top) + var(--decorator-border-width));
  left: calc(var(--decorator-outer-offset-left) + var(--decorator-border-width));
  content: ' ';
  display: block;
  width: calc(var(--decorator-outer-dim) - (var(--decorator-border-width) * 2));
  height: calc(var(--decorator-outer-dim) - (var(--decorator-border-width) * 2));
  border-radius: calc((var(--decorator-outer-dim) - (var(--decorator-border-width) * 2)) / 2);
  background-color: #555;
}

.blocks:last-child .decorator{ /* slightly shortens it */
  margin-bottom: 0.25in;
}

/***** fine-tunes on the details block where the real juice is *****/

.details{
  flex: 1 0 0;
  padding-left: var(--decorator-horizontal-margin);
  padding-top: calc(var(--row-blocks-padding-top) - 0.5pt) !important; /* not sure why but this is needed for better alignment */
}

.details header{
  color: #000;
}

.details h3{
  font-size: 9pt;
}

.main-block:not(.concise) .details div{
  margin: 0.1in 0 0.1in 0; 
}

.main-block:not(.concise) .blocks:last-child .details div{
  margin-bottom: 0;
}

.main-block.concise .details div:not(.concise){
  /* use padding to work around the fact that margin doesn't affect floated
     neighboring elements */
  padding: 0.05in 0 0.07in 0;
}

.details .place{
  font-size: 8.5pt;
}

.details .location{
  float: right;
}

.details div{
  clear: both;
}

.details .location::before{
  display: inline-block;
  position: relative;
  right: 3pt;
  top: 0.25pt;
  font-family: FontAwesome;
  font-weight: normal;
  font-style: normal;
  text-decoration: inherit;
  content: "\f041";
}

/***** fine-tunes on the lists... *****/

#main ul{
  padding-left: 0.07in;
  margin: 0.08in 0;
}

#main li{
  margin: 0 0 0.025in 0;
}

/****** customize list symbol style ******/
#main li::before{
  position: relative;
  margin-left: -4.25pt;
  content: '• ';
}

.details .concise ul{
  margin: 0 !important;
  -webkit-columns: 2;
  -moz-columns: 2;
  columns: 2;
}

.details .concise li{
  margin: 0 !important;
}

.details .concise li{
  margin-left: 0 !important;
}



/* sidebar */

#sidebar h1{
  font-weight: 400;
  font-size: 11pt;
}

.side-block{
  <!--margin-top: 0.5in; -->
}

#contact ul{
  margin-top: 0.05in;
  padding-left: 0;
  font-family: "Source Code Pro";
  font-weight: 400;
  line-height: 1.75;
}

#contact li > i{
  width: 9pt; /* for text alignment */
  text-align: right;
}

#skills{
  line-height: 1.5;
}

#skills ul{
  margin: 0.05in 0 0.15in;
  padding: 0;
}

#disclaimer{
  position: absolute;
  bottom: var(--sidebar-horizontal-padding);
  right: var(--sidebar-horizontal-padding);
  font-size: 7.5pt;
  font-style: italic;
  line-height: 1.1;
  text-align: right;
  color: #777;
}

#disclaimer code{
  color: #666;
  font-family: "Source Code Pro";
  font-weight: 400;
  font-style: normal;
}
	</style>
  </head>
  <body lang="en">
    <section id="main">
      <header id="title">
        <h1>Aleksandur Gyuzelov</h1>
        <span class="fa fa-envelope">aguzelov@outlook.com</span>
		</br>
		<span class="fa fa-linkedin"><a href="https://www.linkedin.com/in/aleksandur-gyuzelov">linkedin.com/in/aleksandur-gyuzelov</a></span>
		</br>
		<span class="fa fa-phone">0888 07 27 10</span>
      </header>
      <section class="main-block">
        <h2>
          <i class="fa fa-folder-open"></i> Courses
        </h2>
        <section class="blocks">
          <div class="date">
            <span>01.07.2017</span><span>04.09.2017</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>Programming Basics with JAVA</h3>
			  <span class="place">Grade 6.0</span>
			  </br>
              <span class="place"><a href="https://softuni.bg/certificates/details/22959/ef96021c">Certificate</a></span>
            </header>
            <div>
              <span class="place">Курсът "Programming Basics" дава начални умения по програмиране, необходими за всички технологични специалности в Софтуерния университет. Това включва писане на програмен код на начално ниво (basic coding skills), работа със среда за разработка (IDE), използване на променливи и данни, оператори и изрази, работа с конзолата (четене на входни данни и печатане на резултати), използване на условни конструкции (if, if-else) и цикли (for, while, do-while).

Курсът завършва с практически изпит по програмиране, който е приемен в програмата по софтуерно инженерство на Софтуерния университет.</span>
            </div>
          </div>
        </section>
        <section class="blocks">
          <div class="date">
            <span>18.09.2017</span><span>05.11.2017</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>Programming Fundamentals</h3>
			  <span class="place">Grade 6.0</span>
			  </br>
              <span class="place"><a href="https://softuni.bg/certificates/details/24143/8826089c">Certificate</a></span>
            </header>
            <div>
              <span class="place">Курсът "Programming Fundamentals" разширява натрупаните до момента начални умения за писане на програмен код от курса "Основи на програмирането" и запознава с базови техники и инструменти за практическо програмиране отвъд писането на прости програмни конструкции.

Курсът обхваща запознаване с типовете данни в програмирането и техните особености, изваждане на парчета код в методи с параметри и връщана стойност, използване на дебъгер за проследяване изпълнението на кода и намиране на грешки, обработка на поредици елементи чрез масиви и списъци, използване на колекции, работа с матрици за обработка на таблични данни, работа с речници и асоциативни масиви за обработка и съхранение на двойки {ключ - стойност}, работа със стрингове и текстообработка и основни познания за работа с класове и обекти, използване на API класове и дефиниране на собствени класове.

Наред с техниките за програмиране курсът развива алгоритмично мислене и изгражда умения за решаване на задачи чрез работа върху стотици практически упражнения. Всички задачи за упражнения и домашни се оценяват в реално време с автоматизираната SofUni online judge система. Курсът завършва с практически изпит по програмиране.</span>
            </div>
          </div>
        </section>
        <section class="blocks">
          <div class="date">
            <span>06.11.2017</span><span>04.01.2018</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>Software Technologies</h3>
			  <span class="place">Grade 6.0</span>
			  </br>
              <span class="place"><a href="https://softuni.bg/certificates/details/50589/e2d4c95f">Certificate</a></span>
            </header>
            <div>
              <span class="place">Курсът "Software Technologies" дава начални познания по най-използваните софтуерни технологии в практиката и позволява на студентите да се ориентират кои технологии им харесват, за да ги изучават по-задълбочено. Изучават се базови концепции от front-end и back-end разработката. Курсът се състои от четири части: HTML5 разработка (HTML + CSS + JavaScript + AJAX + REST), PHP уеб разработка (PHP + MySQL), C# уеб разработка (ASP.NET MVC + Entity Framework + SQL Server) и Java уеб разработка (Java + Spring MVC + Hibernate + MySQL).

Методиката на обучение е изключително практическа. Изучаваният материал е представен с малко теория, с многобройни примери и огромно количество практически задачи с нарастваща трудност и надграждащи се една след друга, с подробни постъпкови указания. Практическата работа в клас под надзора на преподаватели и асистенти (или вкъщи за онлайн студентите) е над 70%. Курсът само запознава с изучаваните технологии и дава съвсем начални умения без да влиза в дълбочина. Целта не е научаване на обхванатите технологии, а запознаване с тях.

В първите няколко теми студентите се запознават с HTML5 платформата. Чрез много практически упражнения се изучават основите на езика за описание на уеб съдържание HTML в комбинация с езика за стилизиране на уеб съдържание CSS и езика JavaScript, с който се изграждат динамични клиентски уеб приложения, изпълнявани в уеб браузъра (front-end разработка). Изучават се базови елементи на езика JavaScript - неговият синтаксис, обхват на променливите, условни конструкции, цикли, масиви, обекти, функции и работа с тях, достъп до елементите в страницата през DOM. Продължава се с практическо използване на технологията AJAX за извличане на данни от REST услуги и достъп до BaaS услуга за съхранение на данни в cloud среда (Kinvey). За да свържат всичко изучавано до момента, като практически проект студентите изграждат проста блог система, базирана на HTML5, AJAX и REST услуга.

В следващите няколко теми студентите се запознават с PHP и MySQL. След инсталация и конфигурация на работна среда за PHP (XAMPP или LAMP), те се запознават с езика, неговият синтаксис, условни конструкции, цикли, масиви, функции. Продължава се с много кратко запознаване на HTTP протокола и обработка на GET и POST заявки с PHP. Следва много кратко запознаване с релационните бази данни и MySQL чрез примери и практически упражнения. Изучава се дефинирането на таблици и връзки между тях, писане на много прости SQL заявки и достъп до МySQL от PHP - извличане, добавяне, промяна и изтриване на редове. За да свържат всичко изучавано в последните няколко теми, като практически проект студентите изграждат проста блог система, базирана на PHP и MySQL.

След като преминат през тези теми, студентите се запознават със C# Web разработката. Започва се с практическо опознаване на MS SQL Server и технологията Entity Framework за достъп до данни от C# приложения. Следват основите на технологията за изграждане на сървърни уеб приложения ASP.NET MVC - изгледи, контролери, модели, форми, достъп до данни, регистрация на потребители и вход (login). Следва разработка на практически проект - проста блог система, базирана на ASP.NET MVC, Entity Framework и SQL Server.

В последните няколко теми студентите се запознават с Java Web разработката. Започва се с кратко въведение в езика Java - синтаксис, променливи, условни конструкции, цикли, масиви, списъци, класове и обекти. Следва запознаване с Hibernate ORM и достъпа до MySQL база данни от Java. Продължава се с Java Web приложенията (Servlets / JSP) и технологията за Java уеб разработка Spring MVC. Следва разработка на практически проект - проста блог система, базирана на Java, Spring MVC, Hibernate и MySQL.</span>
            </div>
          </div>
        </section>
		<section class="blocks">
          <div class="date">
            <span>22.01.2018</span><span>09.02.2018</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>C# Advanced</h3>
			  <span class="place">Grade 6.0</span>
			  </br>
              <span class="place"><a href="https://softuni.bg/certificates/details/51389/ffe2791d">Certificate</a></span>
            </header>
            <div>
              <span class="place">Курсът C# Advanced разглежда .NET платформата, както и работата с езика C# на ниво над началното. Това включва писане на код (coding skills), решаване на проблеми от средно-алгоритмичен характер (problem solving skills), запознаване със стандартнатите инструменти за работа (.NET Framework) пр. инструменти за текстообработка, линейни и дървовидни колекции и работа с файлове и директории. Обръща се внимание на парадигмата функционално програмиране, както и на основния инструмент залагащ на нея - LINQ за обработване на потоци от данни. В курса ще се разгледа и асинхронно програмиране, а през цялото време на обучение курсистите ще са разделени на отбори, които ще трябва да направят практически проект. Средата за разработка, която ще се използва от трейнърския екип е Microsoft Visual Studio 2015 + JetBrains ReSharper, но всеки курсист е свободен да използва инструменти по предпочитание.

Курсът е част от цялостната програма с C# курсове и уроци за обучение по професия "C# програмист" в Софтуерния университет.</span>
            </div>
          </div>
        </section>
		<section class="blocks">
          <div class="date">
            <span>22.01.2018</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>C# OOP Basics</h3>
			  <span class="place">Current course</span>
			</header>
            <div>
              <span class="place">Курсът "Object-Oriented Programming" ще ви научи на принципите на обектно-ориентираното програмиране (ООП), как да работите с класове и обекти, как да ползвате обектно-ориентирано моделиране и да изграждате йерархии от класове. Ще се изучават основните принципи на ООП като абстракция (интерфейси, абстрактни класове), енкапсулация, наследяване и полиморфизъм. Ще обърнем внимание на парадигми като event-driven програмиране, функционално програмиране (ламбда функции, closures и LINQ), обработка на изключения. Ще разгледаме как се клонират, сравняват и обхождат обекти. Ще навлезем накратко в най-често използваните шаблони за дизайн (design patterns). Примерите, домашните и проектите ще са на езиците C#, Java и PHP.

Оценяването в курса по ООП е на базата на предадени домашни, практически екипни проекти и практически изпит по ООП.

Курсът е част от цялостната програма с C# курсове и уроци за обучение по професия "C# програмист" в Софтуерния университет.</span>
            </div>
          </div>
        </section>
      </section>
	  <section class="main-block">
        <h2>
          <i class="fa fa-folder-open"></i> Open Courses
        </h2>
        <section class="blocks">
          <div class="date">
            <span>27.02.2017</span><span>21.05.2017</span>
          </div>
          <div class="decorator">
          </div>
          <div class="details">
            <header>
              <h3>C++ Programming</h3>
			  <span class="place">Grade 5.19</span>
			  </br>
              <span class="place"><a href="https://softuni.bg/certificates/details/20383/57d03a7f">Certificate</a></span>
            </header>
            <div>
              <span class="place">Курсът има за цел да запознае участниците с основите и спецификите на C++ и способите му за обектно-ориентирано програмиране, работа с паметта и често ползвани структури данни. Заедно с това курсистите ще се запознаят с добри практики за организация и писане на качествен код и ще решават задачи, които да утвърдят познанията им върху материала. </span>
            </div>
          </div>
        </section>
      </section>
    </section>
    <aside id="sidebar">
      <div class="side-block" id="contact">
        <a href="https://softuni.bg/about"> <img alt="SoftUni Code Wizard" src="https://upload.wikimedia.org/wikipedia/commons/7/76/Logo_Software_University_%28SoftUni%29_-_blue.png" style="float:right;padding-left:10px;" width="180"> </a>
      </div>
    </aside>
  </body>
</html>