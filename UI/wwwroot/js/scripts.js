document.getElementById('cc-form').addEventListener('submit', async function (e) {
    e.preventDefault();
    const ccNumber = document.getElementById('cc-number').value;
    const response = await fetch('https://localhost:5001/api/CreditCard/Validate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ cardNumber: ccNumber })
    });
    const result = await response.json();
    document.getElementById('result').innerText = result.message;
});

document.getElementById('cancel-button').addEventListener('click', function () {
    document.getElementById('cc-number').value = '';
    document.getElementById('result').innerHTML = '';
});
