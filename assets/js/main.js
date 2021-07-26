$(document).ready(function () {
  // modal start

  $(".bookinglink").click(function (e) {
    e.preventDefault();
    $("#modal").fadeIn();
  });

  $(".close-icon").click(function (e) {
    e.preventDefault();
    $("#modal").fadeOut();
  });

  $("html , body").keydown(function (x) {
    if (x.which == 27) {
      $("#modal").fadeOut();
    }
  });

  window.addEventListener("click", function (e) {
    if ($(e.target).hasClass("modal")) {
      $("#modal").fadeOut();
    }
  });

  // modal ends

  // navbar sticking starts

  $(window).scroll(function () {
    if ($("html").scrollTop() >= 100) {
      $(".prenavbar").addClass("scrolled");
    } else {
      $(".prenavbar").removeClass("scrolled");
    }
  });

  // navbar sticking end

  // slider testimonial start
  $(".carousel").slick({
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 3,
    dots: true,
    responsive: [
      
      {
        breakpoint: 770,
        settings: {
          slidesToShow: 1,
          slidesToScroll:1 
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ]
  });

  //  slider testimonial end

  // slider store start
  $("#store .slider").slick({
    infinite: true,
    slidesToShow: 2,
    slidesToScroll: 2,
    responsive: [
      
      {
        breakpoint: 770,
        settings: {
          slidesToShow: 2,
          slidesToScroll:2 
        }
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ]
  });

  //  slider store end

  // about slider starts
$("#story .slider-about").slick({
  infinite: true,
  slidesToShow: 1,
  slidesToScroll: 1,
  responsive: [
      
    {
      breakpoint: 770,
      settings: {
        slidesToShow: 2,
        slidesToScroll:2 
      }
    },
    {
      breakpoint: 576,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    }
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
});
  // about slider ends

  // slider single item start

  $("#single-item .slider").slick({
    infinite: true,
    slidesToShow: 2,
    slidesToScroll: 2,
    dots: true,
  });

  //  slider single item end

  //item zooming starts

  $(".play-btn").magnificPopup({
    disableOn: 700,
    type: "iframe",
    mainClass: "mfp-fade",
    removalDelay: 160,
    preloader: false,
    fixedContentPos: true,
  });

  $(".zoom").click(function (e) {
    e.preventDefault();
    $("#menus .context .left img").each(function (x) {
      x.preventDefault();
      var source = $(this).attr("src");

      $(this).parent().attr("href", source);
    });
  });

  $(".image-link").click(function (e) {
    e.preventDefault();

    $("#items .item .image img").each(function () {
      var source = $(this).attr("src");

      $(this).prev().children().attr("href", source);

      console.log(source);
    });
  });

  $(".about-image-link").click(function (e) {
    e.preventDefault();

    $("#story .story-images .slider-abput img").each(function () {
      var source = $(this).attr("src");

      $(this).parent().attr("href", source);

      console.log(source);
    });
  });

  $(".zoom").magnificPopup({
    disableOn: 700,
    type: "image",
    mainClass: "mfp-fade",
    removalDelay: 160,
    preloader: false,
    fixedContentPos: true,
  });

  $("#items .image-link").magnificPopup({
    disableOn: 700,
    type: "image",
    mainClass: "mfp-fade",
    removalDelay: 160,
    preloader: false,
    fixedContentPos: true,
  });

  //item zooming ends

  // back to top starts

  $(".back").click(function (e) {
    e.preventDefault();
    $("html").animate(
      {
        scrollTop: 0,
      },
      1000
    );
  });

  // back to top ends

  // menu tabs starts

  $(".menu-tabs .tabs li").each(function (e) {
    $(this).click(function (e) {
      e.preventDefault();
      console.log("kk");

      $(".menu-tabs .tabs li.active").removeClass("active");
      $(this).addClass("active");

      var href = $(this).attr("href");

      $(".menus ul.show").removeClass("show");
      $(href).addClass("show");

      if ($(".menus ul#main").hasClass("show")) {
        $("#specialities").css(
          "background-image",
          "url(./assets/images/specialitites/maindish.jpg)"
        );
      } else if ($(".menus ul#starter").hasClass("show")) {
        $("#specialities").css(
          "background-image",
          "url(./assets/images/specialitites/starter.jpg)"
        );
      } else if ($(".menus ul#dessert").hasClass("show")) {
        $("#specialities").css(
          "background-image",
          "url(./assets/images/specialitites/dessert.jpg)"
        );
      } else if ($(".menus ul#sea").hasClass("show")) {
        $("#specialities").css(
          "background-image",
          "url(./assets/images/specialitites/seafood.jpg)"
        );
      } else {
        $("#specialities").css(
          "background-image",
          "url(./assets/images/specialitites/drinks.jpg)"
        );
      }
    });
  });

  // menu tabs ends

  // odometr starts

  $(window).scroll(function () {
    var hT = $("#stats").offset().top,
      hH = $("#stats").outerHeight(),
      wH = $(window).height(),
      wS = $(this).scrollTop();
    if (wS > hT + hH - wH && hT > wS && wS + wH > hT + hH) {
      let odometers = document.querySelectorAll(".odometer");

      let speed = 300;

      odometers.forEach((counter) => {
        let updateCount = () => {
          let target = +counter.getAttribute("data-target");
          let count = +counter.innerText;

          let inc = Math.ceil(target / speed);

          if (count < target) {
            counter.innerText = count + inc;
            setTimeout(updateCount, 10);
          } else {
            count.innerText = target;
          }
        };

        updateCount();
      });
    }
  });

  // odometer ends

  $("#menus .menu-tabs ul li").each(function (e) {
    $(this).click(function (e) {
      e.preventDefault();

      $(".menu-tabs ul li.active").removeClass("active");
      $(this).addClass("active");

      var href = $(this).attr("href");

      $(".menu-boxes div.show").removeClass("show");
      $(href).addClass("show");
    });
  });

  //filter starts
  $("#range").ionRangeSlider({
    min: 0,
    max: 1000,
    from: 0,
  });
  //filter sends

  //fancybox starts

  Fancybox.bind('[data-fancybox="gallery"]', {
    //dragToClose: false,
    Thumbs: false,

    Image: {
      zoom: false,
      click: false,
      wheel: "slide",
    },

    on: {
      // Move caption inside the slide
      reveal: (f, slide) => {
        slide.$caption && slide.$content.appendChild(slide.$caption);
      },
    },
  });

  Fancybox.bind('[data-fancybox="gallery2"]', {
    //dragToClose: false,
    Thumbs: false,

    Image: {
      zoom: false,
      click: false,
      wheel: "slide",
    },

    on: {
      // Move caption inside the slide
      reveal: (f, slide) => {
        slide.$caption && slide.$content.appendChild(slide.$caption);
      },
    },
  });


  //fancybox ends

  //footer email validation 
  

  $(".sub button.btn-submit").click(function(e){
    e.preventDefault();
    e.stopImmediatePropagation()
    var email = $("footer #footer-middle input[type='email']");

    function validateEmail(email) {
      const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    if (email.val() == "") {
          email.css("border-color", "red");
          email.attr("placeholder", "Fill the input!!!");
        } else {
          email.css("border-color", "#eee");
          email.attr("placeholder", "");
        }
  })


  // $("#message .send").click(function (e) {
  //   e.preventDefault();

  //   var name = $("#message .drop input[type='name']");
  //   var email = $("#message .drop input[type='email']");
  //   var txt = $("#message .drop textarea[name='message']");
  //   var labelEmail = $("#message .drop label[for='email']");
  //   var labelName = $("#message .drop label[for='name']");

  //   if (name.val() == "") {
  //     name.css("background-color", "#ffc1c1");
  //     name.attr("placeholder", "Fill the input!!!");
  //   } else {
  //     name.css("background-color", "#EFF2FA");
  //     name.attr("placeholder", "");
  //   }

  //   function validateEmail(email) {
  //     const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  //     return re.test(email.val());
  //   }

  //   function validateName(name) {
  //     const re = /^[a-zA-Z\s]*$/;

  //     return re.test(name.val());
  //   }
  //   function emailValidation() {
  //     if (validateEmail(email)) {
  //       labelEmail.hide();
  //       return true;
  //     } else {
  //       labelEmail.show();
  //       return false;
  //     }
  //   }

  //   function nameValidation() {
  //     if (!validateName(name)) {
  //       labelName.show();
  //       return false;
  //     } else {
  //       labelName.hide();
  //       return true;
  //     }
  //   }

  //   if (email.val() == "") {
  //     email.css("background-color", "#ffc1c1");
  //     email.attr("placeholder", "Fill the input!!!");
  //   } else {
  //     email.css("background-color", "#EFF2FA");
  //     email.attr("placeholder", "");
  //   }

  //   if (txt.val() == "") {
  //     txt.css("background-color", "#ffc1c1");
  //     txt.attr("placeholder", "Fill the input!!!");
  //   } else {
  //     txt.css("background-color", "#EFF2FA");
  //     txt.attr("placeholder", "");
  //   }

  //   name.focus(function (e) {
  //     e.preventDefault();
  //     $(this).css("background-color", "#EFF2FA");
  //     $(this).attr("placeholder", "");
  //   });

  //   email.focus(function (e) {
  //     e.preventDefault();
  //     $(this).css("background-color", "#EFF2FA");
  //     $(this).attr("placeholder", "");
  //   });

  //   txt.focus(function (e) {
  //     e.preventDefault();
  //     $(this).css("background-color", "#EFF2FA");
  //     $(this).attr("placeholder", "");
  //   });

  //   if (name.val() != "" && email.val() != "" && txt.val() != "") {
  //     if (emailValidation() && nameValidation()) {
  //       $(".success").fadeIn();
  //       document.forms[0].reset();

  //       setTimeout(function () {
  //         $(".success").fadeOut();
  //       }, 3000);
  //     }
  //   } else {
  //     $(".success").fadeOut();
  //   }
  // });
});
