import java.io.*;
import java.util.HashMap;

import concretes.BinarySearchTree;
import concretes.Node;


public class Hash {
	static Node nodeAtIndex;
	static Node[] hashTable;
	static int sizeOfHashTable;
	static int numberInsertedElements;
	static String elementsOfHashTable = "";
	static BinarySearchTree binarySearchTree = new BinarySearchTree();
	
	
	public static void main(String[] args) {
		
		int value;
		String input = null;
		
		BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));
		HashMap<Integer, Integer> hashMap = new HashMap<Integer, Integer>();
		
		System.out.println("---- Ýkili arama aðacý ile hash uygulamasý ----");
		System.out.println();
		System.out.print("Hash tablosu kaç slotlu (boyutlu) olsun (Lütfen sayý giriniz): ");
		
		// Hash tablosunun boyutu için kullanýcýdan veri istenir
		try {
			input = bufferedReader.readLine();
			
			// Girilen deðerin tam sayý olup olmadýðý kontrol edilir
			if (isInt(input)) {
				sizeOfHashTable = Integer.parseInt(input);
				
				// Girilen boyuta göre Node dizi oluþturulur 
				hashTable = new Node[sizeOfHashTable];
				System.out.println();
				
				// Kullanýcý bilgilendirilir
				System.out.println("Hash tablosu " + sizeOfHashTable + " slotlu olarak oluþturuldu.");
			}
		} catch (IOException ioException) {
			ioException.printStackTrace();
		} 
		
		// Kullanýcý q deðerini giresiye kadar deðer ister 
		while(!input.equals("q")) {
			
			
			System.out.print("Aþaðýda bulunan iþlemlerden birini seçerek yanýnda bulunan kodu giriniz" +
			"\n=> Yazdýr (1)" +
			"\n=> Ekle (2) " +
			"\n=> Bul (3)" + 
			"\n=> Çýk (q)" +
			"\nSeçiminiz : ");
			
			
			try {
				input = bufferedReader.readLine();
			} catch (IOException ioException) {
				ioException.printStackTrace();
			}
			
			
			
			
				//Hash tablosunun içeriðini gösteren methodu çaðýrýr
				if(input.equals("1")) {
					PrintHashTable();
				
				}
				// Hash tablosuna veri eklemek için gereken methodu çaðýrýr
				else if(input.equals("2")) { 
					System.out.println("------------------- EKLEME ----------------------");
					System.out.print("Lütfen hash tablosuna sayý eklemek için sayý giriniz : ");
				
					
					try {
						input = bufferedReader.readLine();
						System.out.println();
						
						if (isInt(input)) {
							value = Integer.parseInt(input);
							
							// Sayýnýn aðaç yapýsýnda mevcut olup olamdýðýný kontrol eder
							if (!hashMap.containsKey(value)) {
								
								AddElement(value);
								hashMap.put(value, 1);
								numberInsertedElements++;
								
								System.out.println( value + " sayýsý baþarýlý bir þekilde hash tablosuna eklendi!");
								System.out.println();
							} else {
								System.out.println(value + " sayýsý zaten hash tablosunda mevcuttur!");
								System.out.println();
							}
					
						} else {
							if (!input.equals("q"))
								System.out.println("Hata! Geçersiz bir deðer girdiniz.");
							else
								input = "q";
						}
						
					} catch (IOException ioException) {
						ioException.printStackTrace();
					} 
					
				}
				// Aðaç yapýsýnda bulunan sayýlarý içerisinde kullancýnýn girdiði sayýsýnýn olup olmadýðý kontrol edilir.
				else if(input.equals("3")) {
					System.out.println("---------- BULMA ----------");
					System.out.print("Lütfen hash tablosunda aramak istediðiniz sayýyý giriniz: ");
					
				
					try {
						input = bufferedReader.readLine();
						System.out.println();
						
						if (isInt(input)) {
							
							int number = Integer.parseInt(input);
							
							if (searchInHashTable(number)) {
								System.out.println(number + " sayýsý hash tablosunda mevcuttur!");
								System.out.println();
							} else {
								System.out.println(number + " sayýsý hash tablosunda bulunmamaktadýr!");
								System.out.println();
							}
						} else {
							System.out.println("Hata! Geçersiz deðer girdiniz.");
							System.out.println();
						}
								
					} catch (IOException ioException) {
						ioException.printStackTrace();
					} 
					
				}
				else if(input.equals("q")) {
					input = "q";
					
				}
				else {
					System.out.println();
					System.out.println("Hata! Lütfen kodlardaki deðerlerden birini giriniz.");
					System.out.println();
					
				} 
					
			} 
	
		}
		
	
	// Eklenmek istenilen sayýnýn hash tablosunda bulunmasý gereken yer tespit edilir
	public static int findIndex(int numberToInsert) {
		int index;
		index = numberToInsert % (sizeOfHashTable);
		return index;
	} 


	// Hash tablosuna eleman ekler
	public static void AddElement(int numberToInsert) {

		// Eklenecek olan sayýnýný hash tablosunda bulunmasý gereken yerin tespiti için hashFunction methodu çaðrýlýr
		int index = findIndex(numberToInsert);
		nodeAtIndex = hashTable[index];

		Node newNode = new Node(numberToInsert, null, null, null);

		// Çarpýþma kontrolu yapýlýr
		if (hashTable[index] == null) {
			hashTable[index] = newNode;
		}  
		// Eðer çarpýþma varsa nodeAtIndex deðiþkenini kök olarak kullanýr
		else {
			binarySearchTree.AddNode(newNode, nodeAtIndex);
		}
	}
		
		
	// Parametre olarak gelen deðerin integer olup olmadý regex ifadesiyle kontrol edilir
	public static boolean isInt(String check) {
		return check.matches("\\d+");
	} 
	
	
	// Parametre olarak gelen sayýyý hash tablosu içerisinde arar
	public static boolean searchInHashTable(int number) {
		
		boolean found = false;
		int index = findIndex(number);
		//Slotlarýn boþ olmasý durumu nedeniyle hata alýnmamasý için
		try {
			if (hashTable[index].getElement() == number) {
				found = true;
			} else if (binarySearchTree.searchTree(hashTable[index], number)) {
				found = true;
			}
		}catch(NullPointerException e) {
			
		}
		return found;
	} 
	
	
	// Hash tablosundaki deðerleri sýrasyýla gösterir
	public static void PrintHashTable() {
		
		System.out.println("--------------------------------------------------------------------------------");
		
		// Traverse iþlemiyle tabloda yer  alan deðerler slota göre yazdýrýlýr
		for (int i = 0; i < sizeOfHashTable; i++) {
			System.out.println();
			System.out.print("Slot " + i + "---> ");
			if(hashTable[i] != null) {
				binarySearchTree.inorderTraversalPrint(hashTable[i]);
			}
			System.out.println();
		}
		System.out.println();
		System.out.print("Tüm sayýlar =>  ");

		// Tüm deðerler tek satýrda yazdýlýr
		for (int i = 0; i < sizeOfHashTable; i++) {
			if(hashTable[i] != null) {
				binarySearchTree.inorderTraversalPrint(hashTable[i]);
			}
		}
		System.out.println();
	
	} 

}
