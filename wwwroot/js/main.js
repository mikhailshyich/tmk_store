function counter() {
    const cart = document.querySelector('.card-item');
    try {
        updateCartItemCount();
        function updateCartItemCount() {
            cart.addEventListener('click', (event) => {
                let currenItems, minusBtn, plusBtn, quantityProduct, price;
                if (event.target.matches('.counter-minus') || event.target.matches('.counter-plus')) {
                    const counter = event.target.closest('.counter');
                    const rowCart = event.target.closest('.row-cart');
                    const quantityText = event.target.closest('.col-counter');
                    const costText = rowCart.querySelector('.cost-product');
                    // console.log('counter ', counter);
                    currenItems = counter.querySelector('.counter-text'); // количество товара в поле ввода
                    // console.log('currenItems ', currenItems);
                    minusBtn = counter.querySelector('.counter-minus');
                    plusBtn = counter.querySelector('.counter-plus');
                    quantityProduct = quantityText.querySelector('.quantity-product-text').textContent; // количество оставшегося товара
                    // console.log('quantityProduct ', quantityProduct)
                    costProduct = costText.querySelector('.cost-product-text').textContent;
                    // console.log('cost ', costProduct);
                }

                if (event.target.matches('.counter-plus')) {
                    if (parseInt(currenItems.value) < parseInt(quantityProduct)) {
                        currenItems.value = ++currenItems.value;
                        minusBtn.removeAttribute('disabled');
                    }
                    else {
                        plusBtn.setAttribute('disabled', true);
                    }
                    //calculareTotalPrice();
                }
                if (event.target.matches('.counter-minus')) {
                    if (parseInt(currenItems.value) >= 2) {
                        currenItems.value = --currenItems.value;
                        minusBtn.removeAttribute('disabled');
                        plusBtn.removeAttribute('disabled');
                    }
                    else if (parseInt(currenItems.value) === 1) {
                        minusBtn.setAttribute('disabled', true);
                    }
                    else if (parseInt(currenItems.value) < parseInt(quantityProduct)) {
                        plusBtn.removeAttribute('disabled');
                    }
                    else {
                        currenItems.value = --currenItems.value;
                        minusBtn.setAttribute('disabled', true);
                    }
                    //calculareTotalPrice();
                }
            });
            cart.addEventListener('input', (event) => {
                const counter = event.target.closest('.counter');
                const rowCart = event.target.closest('.row-cart')
                const quantityText = event.target.closest('.col-counter');
                const costText = rowCart.querySelector('.cost-product');
                // console.log('counter ', counter);
                currenItems = counter.querySelector('.counter-text');
                // console.log('currenItems ', currenItems);
                plusBtn = counter.querySelector('.counter-plus');
                minusBtn = counter.querySelector('.counter-minus');
                quantityProduct = quantityText.querySelector('.quantity-product-text').textContent;
                costProduct = costText.querySelector('.cost-product-text').textContent;

                if (parseInt(currenItems.value) <= 0 || currenItems.value === "") {
                    currenItems.value = 1;
                }
                else if (parseInt(currenItems.value) > parseInt(quantityProduct)) {
                    currenItems.value = parseInt(quantityProduct);
                }
                else if (parseInt(currenItems.value) > quantityProduct) {
                    currenItems.value = quantityProduct;
                    plusBtn.setAttribute('disabled', true);
                    minusBtn.removeAttribute('disabled');
                }
                else if (parseInt(currenItems.value) <= quantityProduct) {
                    minusBtn.removeAttribute('disabled');
                    plusBtn.removeAttribute('disabled');
                }
                //calculareTotalPrice();
            });
        }

        const calculareTotalPrice = () => {
            const cartItems = document.querySelectorAll('.card-item-body');
            const cartTotalPrice = document.querySelector('.total-price');
            // console.log('items ', cartItems);
            // console.log('cost ', cartTotalPrice);

            let totalCartValue = 0;
            cartItems.forEach((item) => {
                const itemCount = item.querySelector('.counter-text');
                // console.log('itemCount ', itemCount);

                const itemPrice = item.querySelector('.cost-product-text');
                // console.log('itemPrice ', itemPrice);

                const itemTotalPrice = parseInt(itemCount.value) * parseFloat(itemPrice.textContent);
                // console.log('itemTotalPrice ', itemTotalPrice);

                totalCartValue += itemTotalPrice;
            });
            cartTotalPrice.textContent = totalCartValue.toFixed(2);
        };
        //calculareTotalPrice();
    }
    catch { }
}

function searchProducts(elementProduct) {

    const elements = document.querySelectorAll('.page-products');
    const buttonsDiv = document.querySelector('.group-btn');


    if (buttonsDiv != null) {
        const buttons = buttonsDiv.getElementsByClassName('btn');
        for (var i = 0; i < buttons.length; i++) {
            buttons[i].addEventListener("click", function () {
                var current = document.getElementsByClassName("active-btn");
                current[0].className = current[0].className.replace(" active-btn", "");
                this.className += " active-btn";
            });
        }
    }

    elements.forEach(element => {
        if (element === elementProduct) {
            element.classList.add('d-block');
            element.classList.remove('d-none');
        }
        else if (element != elementProduct) {
            element.classList.add('d-none');
            element.classList.remove('d-block');
        }
    });
}

function clearSearch() {
    const elements = document.querySelectorAll('.page-products');
    elements.forEach(element => {
        element.classList.remove('d-none');
        element.classList.remove('d-block');
    });

}