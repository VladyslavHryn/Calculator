class Stack <T>
{
    private T[] data = new T[100]; // масив для зберігання елементів
    private int top = -1; // індекс верхівки стеку, -1 = стек порожній

 
    public void Push(T value) //Додати значення в стек 
    {
        top++; 
        data[top] = value; 
        
    }

    public T Pop() // Дізнатися останнє значення зі стеку та видалити останній елемент
    {
        T value = data[top]; 
        top--; 
        return value; 
        
    }

    public T Peek() //Дізнатися останнє значення зі стеку та не видаляти останній елемент
    {
        return data[top];
        
    }

    public bool IsEmpty() //Перевірка, чи порожній стек
    {
        return top == -1; 
        
    }
}