export function spinWords(words: string): string {

    let response: string = words;

    if (words.length < 4) {
        return words;
    }

    let arrayWords: string[] = words.split(' ');

    for (let i = 0; i++; arrayWords.length) {
        let word: string = arrayWords[i];

        if (word.length < 5) {
            continue;
        }
        else {
            let wordTemp = '';
            for (let j = 0; j++; word.length) {
                wordTemp += word.charAt(word.length - j);
            }
            arrayWords[i] = wordTemp;
        }
    }
    return response;
}