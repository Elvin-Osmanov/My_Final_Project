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
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
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
          slidesToScroll: 2,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
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
          slidesToScroll: 2,
        },
      },
      {
        breakpoint: 576,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
  });
  // about slider ends

  // table remove starts
$(".remove-btn").click(function () {

  $(this).parent().parent().remove();
  
})
  //table remove ends

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
  // review validation starts
  $("#single-item .add-review .add-review-btn").click(function (e){
    e.preventDefault();

    var name = $("#review-name");
    var email = $("#review-email");
    var message = $("#review-message");

    if (email.val() == "") {
      email.css("border-color", "red");
      
    } else {
      email.css("border-color", "#eee");
     
    }

    if (name.val() == "") {
      name.css("border-color", "red");
      
    } else {
      name.css("border-color", "#eee");
      
    }

    if (message.val() == "") {
      message.css("border-color", "red");
      
    } else {
      message.css("border-color", "#eee");
      
    }

    function validateEmail(email) {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    function validateName(name) {
      var reg = new RegExp("^\\d+$");

      return reg.test(name.val());
    }

    function emailValidation() {
      if (validateEmail(email)) {
        email.css("border-color", "#eee");
        return true;
      } else {
        email.css("border-color", "red");
        return false;
      }
    }

    function nameValidation() {
      if (validateName(name)) {
        name.css("border-color", "red");
        return false;
      } else {
        name.css("border-color", "#eee");
        return true;
      }
    }

    if (
      emailValidation() &&
      nameValidation()
    ) {
      $("span.review-success").fadeIn();
      document.forms[0].reset();

      setTimeout(function () {
        $("span.review-success").fadeOut();
      }, 3000);
    } else {
      $("span.review-success").fadeOut();
    }

  })
  // review validation ends

  // checkout validation starts
  $(".pay .pay-btn").click(function (e) {
    e.preventDefault();

    var name = $("#check-name");
    var email = $("#check-email");
    var postcode = $("#check-code");
    var phone = $("#check-phone");
    var city = $("#check-city");
    var country = $("#check-country");
    var phone = $("#check-phone");
    var cardName = $("#card-name");
    var cardNumber = $("#card-number");
    var cardMM = $("#card-mm");
    var cardYY = $("#card-yy");
    var cardCVV = $("#card-cvv");
    var message = $("#card-text");

    if (email.val() == "") {
      email.css("border-color", "red");
      
    } else {
      email.css("border-color", "#eee");
     
    }

    if (name.val() == "") {
      name.css("border-color", "red");
      
    } else {
      name.css("border-color", "#eee");
      
    }

    if (message.val() == "") {
      message.css("border-color", "red");
      
    } else {
      message.css("border-color", "#eee");
      
    }

    if (phone.val() == "") {
      phone.css("border-color", "red");
     
    } else {
      phone.css("border-color", "#eee");
      
    }

    if (postcode.val() == "") {
      postcode.css("border-color", "red");
     
    } else {
      postcode.css("border-color", "#eee");
      
    }

    if (city.val() == "") {
      city.css("border-color", "red");
      
    } else {
      city.css("border-color", "#eee");
    
    }

    if (country.val() == "") {
      country.css("border-color", "red");
     
    } else {
      country.css("border-color", "#eee");
     
    }

    if (cardName.val() == "") {
      cardName.css("border-color", "red");
     
    } else {
      cardName.css("border-color", "#eee");
     
    }

    if (cardNumber.val() == "") {
      cardNumber.css("border-color", "red");
      
    } else {
      cardNumber.css("border-color", "#eee");
      
    }

    if (cardYY.val() == "") {
      cardYY.css("border-color", "red");
     
    } else {
      cardYY.css("border-color", "#eee");
     
    }

    if (cardMM.val() == "") {
      cardMM.css("border-color", "red");
     
    } else {
      cardMM.css("border-color", "#eee");
    
    }

    if (cardCVV.val() == "") {
      cardCVV.css("border-color", "red");
     
    } else {
      cardCVV.css("border-color", "#eee");
      
    }

    function validateEmail(email) {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    function validatePhone(phone) {
      var reg = new RegExp('@"^d$"');
      return reg.test(phone.val());
    }

    function validateName(name) {
      var reg = new RegExp("^\\d+$");

      return reg.test(name.val());
    }

    function validateCity(city) {
      var reg = new RegExp("^\\d+$");

      return reg.test(city.val());
    }

    function validateCVV(cardCVV) {
      var reg = /^[0-9]{3,4}$/

      return reg.test(cardCVV.val());
    }

    function validateMM(cardMM){
      var reg = /^0[1-9]|1[0-2]/

      return reg.test(cardMM.val());
    }

    function validateYY(cardYY){
      var reg = /^\d{2}$/

      return reg.test(cardYY.val());
    }

    function validateCardnumber(cardNumber) {
      var reg = /^\d{16}$/

      return reg.test(cardNumber.val());
    }

    function validateCountry(country) {
      var reg = new RegExp("^\\d+$");

      return reg.test(country.val());
    }

    function validateCName(cardName) {
      var reg = new RegExp("^\\d+$");

      return reg.test(cardName.val());
    }
    function emailValidation() {
      if (validateEmail(email)) {
        email.css("border-color", "#eee");
        return true;
      } else {
        email.css("border-color", "red");
        return false;
      }
    }

    function CvvValidation() {
      if (validateCVV(cardCVV)) {
        cardCVV.css("border-color", "#eee");
        return true;
      } else {
        cardCVV.css("border-color", "red");
        return false;
      }
    }

    function MMValidation() {  
      if (validateMM(cardMM)) {
        cardMM.css("border-color", "#eee");
        return true;
      } else {
        cardMM.css("border-color", "red");
        return false;
      }
    }

    function YYValidation() {  
      if (validateYY(cardYY)) {
        cardYY.css("border-color", "#eee");
        return true;
      } else {
        cardYY.css("border-color", "red");
        return false;
      }
    }

    
    function cardNumberValidation() {  
      if (validateCardnumber(cardNumber)) {
        cardNumber.css("border-color", "#eee");
        return true;
      } else {
        cardNumber.css("border-color", "red");
        return false;
      }
    }


    function nameValidation() {
      if (validateName(name)) {
        name.css("border-color", "red");
        return false;
      } else {
        name.css("border-color", "#eee");
        return true;
      }
    }

    function CnameValidation() {
      if (validateCName(cardName)) {
        cardName.css("border-color", "red");
        return false;
      } else {
        cardName.css("border-color", "#eee");
        return true;
      }
    }

    function cityValidation() {
      if (validateCity(city)) {
        city.css("border-color", "red");
        return false;
      } else {
        city.css("border-color", "#eee");
        return true;
      }
    }

    function phoneValidation() {
      if (validatePhone(phone)) {
        phone.css("border-color", "red");
        return false;
      } else {
        phone.css("border-color", "#eee");
        return true;
      }
    }
    function countryValidation() {
      if (validateCountry(country)) {
        country.css("border-color", "red");
        return false;
      } else {
        country.css("border-color", "#eee");
        return true;
      }
    }
    if (
      emailValidation() &&
      nameValidation() &&
      phoneValidation() &&
      CnameValidation() &&
      cityValidation() &&
      countryValidation()&&CvvValidation()&&MMValidation()&&YYValidation()&&cardNumberValidation()
    ) {
      $("span.card-success").fadeIn();
      document.forms[0].reset();

      setTimeout(function () {
        $("span.card-success").fadeOut();
      }, 3000);
    } else {
      $("span.card-success").fadeOut();
    }
  });

  // checkout validation ends

  // contact validation starts
  $("#touch .contact-link .contact-btn").click(function (e) {
    //e.preventDefault();

    var name = $("#touch .contact-name");
    var email = $("#touch .contact-email");
    var message = $("#touch .contact-message");
    var phone = $("#touch .contact-phone");

    if (email.val() == "") {
      email.css("border-color", "red");
      
    } else {
      email.css("border-color", "#eee");
      email.attr("placeholder", "");
    }

    if (name.val() == "") {
      name.css("border-color", "red");
      
    } else {
      name.css("border-color", "#eee");
      name.attr("placeholder", "");
    }

    if (message.val() == "") {
      message.css("border-color", "red");
      
    } else {
      message.css("border-color", "#eee");
      message.attr("placeholder", "");
    }

    if (phone.val() == "") {
      phone.css("border-color", "red");
     
    } else {
      phone.css("border-color", "#eee");
      phone.attr("placeholder", "");
    }

    function validateEmail(email) {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    function validatePhone(phone) {
      var reg = new RegExp('@"^d$"');
      return reg.test(phone.val());
    }

    function validateName(name) {
      var reg = new RegExp("^\\d+$");

      return reg.test(name.val());
    }
    function emailValidation() {
      if (validateEmail(email)) {
        email.css("border-color", "#eee");
        return true;
      } else {
        email.css("border-color", "red");
        return false;
      }
    }

    function nameValidation() {
      if (validateName(name)) {
        name.css("border-color", "red");
        return false;
      } else {
        name.css("border-color", "#eee");
        return true;
      }
    }

    function phoneValidation() {
      if (validatePhone(phone)) {
        phone.css("border-color", "red");
        return false;
      } else {
        phone.css("border-color", "#eee");
        return true;
      }
    }

    if (emailValidation() && nameValidation() && phoneValidation()) {
      $("span.contact-success").fadeIn();
      document.forms[0].reset();

      setTimeout(function () {
        $("span.contact-success").fadeOut();
      }, 3000);
    } else {
      $("span.contact-success").fadeOut();
    }
  });

  // contact validation ends

  // modal validation starts
  $("#modal .reserve-btn").click(function (e) {
    e.preventDefault();

    var name = $("#modal #modal-name");
    var email = $("#modal #modal-email");

    var phone = $("#modal #modal-phone");

    if (email.val() == "") {
      email.css("border-color", "red");
     
    } else {
      email.css("border-color", "#eee");
      
    }

    if (name.val() == "") {
      name.css("border-color", "red");
     
    } else {
      name.css("border-color", "#eee");
     
    }

    if (phone.val() == "") {
      phone.css("border-color", "red");
      
    } else {
      phone.css("border-color", "#eee");
      
    }

    if (email.val() == "") {
      email.css("border-color", "red");
     
    } else {
      email.css("border-color", "#eee");
      
    }

    function validateEmail(email) {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    function validateName(name) {
      var reg = new RegExp("^\\d+$");

      return reg.test(name.val());
    }
    function emailValidation() {
      if (validateEmail(email)) {
        email.css("border-color", "#eee");
        return true;
      } else {
        email.css("border-color", "red");
        return false;
      }
    }

    function nameValidation() {
      if (validateName(name)) {
        name.css("border-color", "red");
        return false;
      } else {
        name.css("border-color", "#eee");
        return true;
      }
    }

    if (emailValidation() && nameValidation()) {
      $("#modal .inputs .success").fadeIn();
      document.forms[0].reset();

      setTimeout(function () {
        $("#modal .inputs .success").fadeOut();
      }, 3000);
    } else {
      $("#modal .inputs .success").fadeOut();
    }
  });

  // modal validation ends

  //footer subscribe validation starts
  $(".sub button.btn-submit").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var email = $("footer #footer-middle input[type='email']");

    function validateEmail(email) {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email.val());
    }

    if (email.val() == "") {
      email.css("border-color", "red");
      email.attr("placeholder", "Fill the input!!!");
    } else {
      email.css("border-color", "#eee");
      email.attr("placeholder", "");
    }

    function emailValidation() {
      if (validateEmail(email)) {
        email.css("border-color", "#eee");
        return true;
      } else {
        email.css("border-color", "red");
        return false;
      }
    }

    if (email.val() != "") {
      if (emailValidation()) {
        $("#footer-middle .subsuccess").fadeIn();
        document.forms[0].reset();

        setTimeout(function () {
          $("#footer-middle .subsuccess").fadeOut();
        }, 3000);
      }
    } else {
      $("#footer-middle .subsuccess").fadeOut();
    }
  });
  //footer subscribe validation ends
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

  $("#menus .menu-tabs a").each(function (e) {
    $(this).click(function (e) {
      e.preventDefault();

      $(".menu-tabs a.active").removeClass("active");
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

  

  
});
