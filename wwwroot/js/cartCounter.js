function counter() {
    const cart = document.querySelector('.card-item');

    updateCartItemCount();
    function updateCartItemCount() {
        cart.onreadystatechange = () => {
            if (cart.readyState === 'complete') {
                calculareTotalPrice();
            }
        };
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
                if (parseInt(currenItems.value) < 9999 & parseInt(currenItems.value) < parseInt(quantityProduct)) {
                    currenItems.value = ++currenItems.value;
                    minusBtn.removeAttribute('disabled');
                }
                else {
                    plusBtn.setAttribute('disabled', true);
                }
                calculareTotalPrice();
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
                else if (parseInt(currenItems.value) < 9999) {
                    plusBtn.removeAttribute('disabled');
                }
                else {
                    currenItems.value = --currenItems.value;
                    minusBtn.setAttribute('disabled', true);
                }
                calculareTotalPrice();
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
            else if (parseInt(currenItems.value) > 9999) {
                currenItems.value = 9999;
                plusBtn.setAttribute('disabled', true);
                minusBtn.removeAttribute('disabled');
            }
            else if (parseInt(currenItems.value) <= 9999) {
                minusBtn.removeAttribute('disabled');
                plusBtn.removeAttribute('disabled');
            }
            calculareTotalPrice();
        });
        cart.addEventListener("DOMContentLoaded", () => {
            calculareTotalPrice();
    }

    const calculareTotalPrice = () => {
        const cartItems = document.querySelectorAll('.card-item-body');
        const cartTotalPrice = document.querySelector('.total-price');
        // console.log('items ', cartItems);
        // console.log('cost ', cartTotalPrice);

        let totalCartValue;
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
    calculareTotalPrice();
}