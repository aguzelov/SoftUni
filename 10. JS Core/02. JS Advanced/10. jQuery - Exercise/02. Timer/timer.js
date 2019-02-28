function timer() {
   $('#start-timer').on('click', (e) => {
      if ($('#start-timer').is("[data-disabled]")) {
         console.log('has attribute');
         e.preventDefault();
      } else {
         $('#start-timer').attr('data-disabled', "disabled");

         let start = setInterval(() => {
            let $hours = $('#hours');
            let $minutes = $('#minutes');
            let $seconds = $('#seconds');

            let newSeconds = +$seconds.text() + 1;

            if (newSeconds > 59) {
               let newMinutes = +$minutes.text() + 1;
               if (newMinutes > 59) {
                  let newHours = +$hours.text() + 1;

                  $hours.text(appendLeadingZeroIfNeeded(newHours));
                  $minutes.text('00');
               } else {
                  $minutes.text(appendLeadingZeroIfNeeded(newMinutes));
               }

               $seconds.text('00');
            } else {
               $seconds.text(appendLeadingZeroIfNeeded(newSeconds));
            }

         }, 1000);

         $('#stop-timer').on('click', () => {
            $('#start-timer').removeAttr('data-disabled');
            clearInterval(start);
         });
      }
   });

   function appendLeadingZeroIfNeeded(value) {
      return ('' + value).length === 1 ? '0' + value : value;
   }
}