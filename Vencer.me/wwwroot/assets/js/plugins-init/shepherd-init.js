(function ($) {
  "use strict"

  const tour = new Shepherd.Tour({
    defaultStepOptions: {
      classes: 'shadow-md bg-purple-dark',
      scrollTo: true
    }
  });

  tour.addStep('nav-header', {
    text: 'این نوبار هدر است.',
    attachTo: '.nav-header bottom',
    classes: 'example-step-extra-class',
    advanceOn: '.header-right',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.addStep('header-right', {
    text: 'این هدر سایت است',
    attachTo: '.header-right bottom',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next,
      classes: 'btn btn-primary'
    }]
  });

  tour.addStep('nk-sidebar', {
    text: 'این سایدبار سایت است',
    attachTo: '.nk-sidebar right',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.addStep('right-sidebar', {
    text: 'این سوئیچ تنظیمات سایت است',
    attachTo: '.sidebar-right-trigger left',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.addStep('step 1', {
    text: 'این گام اول است',
    attachTo: '#step1 top',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.addStep('step 2', {
    text: 'این گام دوم است',
    attachTo: '#step2 top',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.addStep('step 3', {
    text: 'این گام سوم است',
    attachTo: '#step3 top',
    classes: 'example-step-extra-class',
    buttons: [{
      text: 'بعدی',
      action: tour.next
    }]
  });

  tour.start();



})(jQuery);