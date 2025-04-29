export function spinWords(words: string): string {

    if (words.length < 4) return words;

    const arrayWords: string[] = words.split(' ');
    for (let i = 0; i < arrayWords.length;  i++) {
        const word: string = arrayWords[i];

        if (word.length >= 5) 
        {
            let wordTemp = '';
            for (let j = word.length - 1; j >= 0; j--) {
                wordTemp += word[j];
            }
            arrayWords[i] = wordTemp;
        }
    }
    return arrayWords.join(' ');
}

