export function spinWords(words: string): string {

    let response: string = "";

    if (words.length < 4) {
        return words;
    }

    let arrayWords: string[] = words.split(' ');

    for (let i = 0; i < arrayWords.length;  i++) {
        const word: string = arrayWords[i];

        if (word.length >= 5) {

            let wordTemp = '';
            for (let j = 0; j <= word.length; j++) {
                wordTemp += word.charAt(word.length - j);
            }
            
            arrayWords[i] = wordTemp;
        }
        if (i == arrayWords.length -1)
        {
            response += arrayWords[i];
        }
        else
        {
            response += arrayWords[i] + ' ';
        }
    }

    return response;
}