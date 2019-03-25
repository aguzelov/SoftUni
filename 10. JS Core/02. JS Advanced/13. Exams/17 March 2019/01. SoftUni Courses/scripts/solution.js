function solve() {
   let $singMeUpButton = $('.courseFoot button');

   $singMeUpButton.on('click', function () {
      let $courses = $('.courseBody ul li');
      let $educationForm = $('#educationForm input');


      let coursePrices = {
         fundamentals: 170,
         advanced: 180,
         applications: 190,
         web: 490
      };

      let checkedCourses = [];

      for (const $course of $courses) {
         if (isChecked($course.children[0])) {
            let courseName = $course.children[1].textContent;
            addToCourseBody(courseName);

            checkedCourses.push(courseName.split(' ')[1].toLowerCase());
         }
      }

      if (checkedCourses.length === 4) {
         addToCourseBody('HTML and CSS');
      }

      for (const type of $educationForm) {
         if (type.checked) {
            calculateCost(checkedCourses, type.value, coursePrices);
         }
      }

      for (const $course of $courses) {
         $course.children[0].checked = false;
      }

   });

   function isChecked($courseInput) {
      return $courseInput.checked;
   }

   function addToCourseBody(courseName) {
      let $courseBody = $('.courseBody ul');

      let $li = $('<li></li>');
      $li.text(courseName.split(' - ')[0].replace(' ', '-'));

      $courseBody.append($li);
   }

   function calculateCost(courses, formType, coursePrices) {


      if (courses.includes('advanced') && courses.includes('fundamentals')) {
         coursePrices['advanced'] = +coursePrices['advanced'] * 0.90;
      }

      if (courses.includes('advanced') && courses.includes('fundamentals') && courses.includes('applications')) {
         coursePrices['fundamentals'] = +coursePrices['fundamentals'] * 0.94;
         coursePrices['advanced'] = +coursePrices['advanced'] * 0.94;
         coursePrices['applications'] = +coursePrices['applications'] * 0.94;
      }



      if (formType === 'online') {
         for (const course of courses) {
            coursePrices[course] = coursePrices[course] - (coursePrices[course] * 0.06);
         }
      }

      let price = 0;
      for (const course of courses) {
         price += coursePrices[course];
      }

      $('.courseFoot p').text('Cost: ' + Math.floor(price) + '.00 BGN');

   }

}

solve();