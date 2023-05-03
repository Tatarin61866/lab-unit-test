using System;
using System.Collections.Generic;
using System.Text;
using UnitTestEx;

namespace UnitTestEx
{
    //класс хранения файла 
    public class FileStorage
    {
        private List<File> files = new List<File>(); //создание саиска файлов 
        private double availableSize = 100;
        private double maxSize = 100;

        /**
         * Construct object and set max storage size and available size according passed values
         * @param size FileStorage size
         */
        //предполагаю что этот метод освобождает место после удаления файла
        public FileStorage(int size)
        {
            maxSize = size;
            availableSize += maxSize;
        }

        /**
         * Construct object and set max storage size and available size based on default value=100
         */
        //пустой метод с таким же названием
        public FileStorage()
        {
        }


        /**
         * Write file in storage if filename is unique and size is not more than available size
         * @param file to save in file storage
         * @return result of file saving
         * @throws FileNameAlreadyExistsException in case of already existent filename
         */
        // Проверка существования файла
        public bool Write(File file)
        {
            if (IsExists(file.GetFilename()))
            {
                //Если файл уже есть, то кидаем ошибку
                throw new FileNameAlreadyExistsException();
            }
            else if (file.GetSize() > availableSize) //Проверка того, размер файла не привышает или равен доступному объему памяти 
            {
                return false;
            }
            else
            {
                // Добалвяем файл в лист
                files.Add(file);
                // обновление свободного объема памяти
                availableSize -= file.GetSize();

                return true;
            }
        }

        /**
         * Check is file exist in storage
         * @param fileName to search
         * @return result of checking
         */
        //перебор в листе файлов и проверка сущестивования 
        public bool IsExists(String fileName)
        {
            // Для каждого элемента с типом File из Листа files
            foreach (File file in files)
            {
                // Проверка имени
                if (file.GetFilename().Contains(fileName))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Delete file from storage
         * @param fileName of file to delete
         * @return result of file deleting
         */
        //удаление файла по имени
        public bool Delete(String fileName)
        {
            return files.Remove(GetFile(fileName));
        }

        /**
         * Get all Files saved in the storage
         * @return list of files
         */
        //вывод листа
        public List<File> GetFiles()
        {
            return files;
        }

        /**
         * Get file by filename
         * @param fileName of file to get
         * @return file
         */
        //выбор файла по имени
        public File GetFile(String fileName)
        {
            if (IsExists(fileName))
            {
                foreach (File file in files)
                {
                    if (file.GetFilename().Contains(fileName))
                    {
                        return file;
                    }
                }
            }
            return null;
        }


        /**
         * Delete all files from files list
         * @return bool
         */
        //удаление всех фалов 
        public bool DeleteAllFiles()
        {
            files.RemoveRange(0, files.Count - 1);
            return files.Count == 0;
        }

    }
}
