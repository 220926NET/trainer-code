function processText() {
    function getAPIKey() {
        fetch('apiKey.txt')
        .then(response => response.text())
        .then(text => apiKey = text);
    }

    let text = document.getElementById('word-cloud-text')?.value;
    if(text) {
        //let's send an http request to our api
        const wordCloudAPI = 'https://textvis-word-cloud-v1.p.rapidapi.com/v1/textToCloud';
        fetch('apiKey.txt')
        .then(response => response.text())
        .then(key => {
            fetch(wordCloudAPI, {
                // mode: 'no-cors',
                method: 'POST',
                headers: {
                    'content-type': 'application/json',
                    'X-RapidAPI-Key': key,
                    'X-RapidAPI-Host': 'textvis-word-cloud-v1.p.rapidapi.com'
                },
                body: JSON.stringify({
                    text: text,
                    scale: 1,
                    width: 800,
                    height: 800,
                    colors: ["#375E97", "#FB6542", "#FFBB00", "#3F681C"],
                    font: "Tahoma",
                    use_stopwords: true,
                    language: "en",
                    uppercase: false
                })
            }).then(response => {
                return response.text();
            })
            .then(wordCloud => {
                var img = document.getElementById("word-cloud");
                img.src = wordCloud;
            })
        });
    }
}



function getRandomText() {
    const apiRoot = 'https://baconipsum.com/api/?type=all-meat';
    //XHR (XML Http Request), they have ready states, it needs a bit more setup
    
    //Fetch API: a newer way to send http requests
    fetch(apiRoot).then((res) => res.json()).then((data) => {
        // document.querySelector('#bacon-text-box').innerHTML = data;
        if(document.getElementById('word-cloud-text'))
        {
            document.getElementById('word-cloud-text').value = data;
        }
    })
}