function Counter() {
    const cart = document.querySelector('.card-item');
    const updateCartItemCount = () => {
        cart.addEventListener('click', (event) => {
            let currenItems, minusBtn;
            if (event.target.matches('.counter-minus') || event.target.matches('.counter-plus')) {
                const counter = event.target.closest('.counter');
                // console.log('counter ', counter);

                currenItems = counter.querySelector('.counter-text');
                // console.log('currenItems ', currenItems);
                minusBtn = counter.querySelector('.counter-minus');
            }

            if (parseInt(currenItems.value) < 1 || parseInt(currenItems.value) > 1000) {
                currenItems.value = 1;
            }

            if (event.target.matches('.counter-plus')) {
                currenItems.value = ++currenItems.value;
                minusBtn.removeAttribute('disabled');
            }
            if (event.target.matches('.counter-minus')) {
                if (parseInt(currenItems.value) > 2) {
                    currenItems.value = --currenItems.value;
                }
                else {
                    currenItems.value = --currenItems.value;
                    minusBtn.setAttribute('disabled', true);
                }
            }
        });
        updateCartItemCount();
    }
}