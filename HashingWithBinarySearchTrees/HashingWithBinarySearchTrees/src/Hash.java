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
		
		System.out.println("---- �kili arama a�ac� ile hash uygulamas� ----");
		System.out.println();
		System.out.print("Hash tablosu ka� slotlu (boyutlu) olsun (L�tfen say� giriniz): ");
		
		// Hash tablosunun boyutu i�in kullan�c�dan veri istenir
		try {
			input = bufferedReader.readLine();
			
			// Girilen de�erin tam say� olup olmad��� kontrol edilir
			if (isInt(input)) {
				sizeOfHashTable = Integer.parseInt(input);
				
				// Girilen boyuta g�re Node dizi olu�turulur 
				hashTable = new Node[sizeOfHashTable];
				System.out.println();
				
				// Kullan�c� bilgilendirilir
				System.out.println("Hash tablosu " + sizeOfHashTable + " slotlu olarak olu�turuldu.");
			}
		} catch (IOException ioException) {
			ioException.printStackTrace();
		} 
		
		// Kullan�c� q de�erini giresiye kadar de�er ister 
		while(!input.equals("q")) {
			
			
			System.out.print("A�a��da bulunan i�lemlerden birini se�erek yan�nda bulunan kodu giriniz" +
			"\n=> Yazd�r (1)" +
			"\n=> Ekle (2) " +
			"\n=> Bul (3)" + 
			"\n=> ��k (q)" +
			"\nSe�iminiz : ");
			
			
			try {
				input = bufferedReader.readLine();
			} catch (IOException ioException) {
				ioException.printStackTrace();
			}
			
			
			
			
				//Hash tablosunun i�eri�ini g�steren methodu �a��r�r
				if(input.equals("1")) {
					PrintHashTable();
				
				}
				// Hash tablosuna veri eklemek i�in gereken methodu �a��r�r
				else if(input.equals("2")) { 
					System.out.println("------------------- EKLEME ----------------------");
					System.out.print("L�tfen hash tablosuna say� eklemek i�in say� giriniz : ");
				
					
					try {
						input = bufferedReader.readLine();
						System.out.println();
						
						if (isInt(input)) {
							value = Integer.parseInt(input);
							
							// Say�n�n a�a� yap�s�nda mevcut olup olamd���n� kontrol eder
							if (!hashMap.containsKey(value)) {
								
								AddElement(value);
								hashMap.put(value, 1);
								numberInsertedElements++;
								
								System.out.println( value + " say�s� ba�ar�l� bir �ekilde hash tablosuna eklendi!");
								System.out.println();
							} else {
								System.out.println(value + " say�s� zaten hash tablosunda mevcuttur!");
								System.out.println();
							}
					
						} else {
							if (!input.equals("q"))
								System.out.println("Hata! Ge�ersiz bir de�er girdiniz.");
							else
								input = "q";
						}
						
					} catch (IOException ioException) {
						ioException.printStackTrace();
					} 
					
				}
				// A�a� yap�s�nda bulunan say�lar� i�erisinde kullanc�n�n girdi�i say�s�n�n olup olmad��� kontrol edilir.
				else if(input.equals("3")) {
					System.out.println("---------- BULMA ----------");
					System.out.print("L�tfen hash tablosunda aramak istedi�iniz say�y� giriniz: ");
					
				
					try {
						input = bufferedReader.readLine();
						System.out.println();
						
						if (isInt(input)) {
							
							int number = Integer.parseInt(input);
							
							if (searchInHashTable(number)) {
								System.out.println(number + " say�s� hash tablosunda mevcuttur!");
								System.out.println();
							} else {
								System.out.println(number + " say�s� hash tablosunda bulunmamaktad�r!");
								System.out.println();
							}
						} else {
							System.out.println("Hata! Ge�ersiz de�er girdiniz.");
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
					System.out.println("Hata! L�tfen kodlardaki de�erlerden birini giriniz.");
					System.out.println();
					
				} 
					
			} 
	
		}
		
	
	// Eklenmek istenilen say�n�n hash tablosunda bulunmas� gereken yer tespit edilir
	public static int findIndex(int numberToInsert) {
		int index;
		index = numberToInsert % (sizeOfHashTable);
		return index;
	} 


	// Hash tablosuna eleman ekler
	public static void AddElement(int numberToInsert) {

		// Eklenecek olan say�n�n� hash tablosunda bulunmas� gereken yerin tespiti i�in hashFunction methodu �a�r�l�r
		int index = findIndex(numberToInsert);
		nodeAtIndex = hashTable[index];

		Node newNode = new Node(numberToInsert, null, null, null);

		// �arp��ma kontrolu yap�l�r
		if (hashTable[index] == null) {
			hashTable[index] = newNode;
		}  
		// E�er �arp��ma varsa nodeAtIndex de�i�kenini k�k olarak kullan�r
		else {
			binarySearchTree.AddNode(newNode, nodeAtIndex);
		}
	}
		
		
	// Parametre olarak gelen de�erin integer olup olmad� regex ifadesiyle kontrol edilir
	public static boolean isInt(String check) {
		return check.matches("\\d+");
	} 
	
	
	// Parametre olarak gelen say�y� hash tablosu i�erisinde arar
	public static boolean searchInHashTable(int number) {
		
		boolean found = false;
		int index = findIndex(number);
		//Slotlar�n bo� olmas� durumu nedeniyle hata al�nmamas� i�in
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
	
	
	// Hash tablosundaki de�erleri s�rasy�la g�sterir
	public static void PrintHashTable() {
		
		System.out.println("--------------------------------------------------------------------------------");
		
		// Traverse i�lemiyle tabloda yer  alan de�erler slota g�re yazd�r�l�r
		for (int i = 0; i < sizeOfHashTable; i++) {
			System.out.println();
			System.out.print("Slot " + i + "---> ");
			if(hashTable[i] != null) {
				binarySearchTree.inorderTraversalPrint(hashTable[i]);
			}
			System.out.println();
		}
		System.out.println();
		System.out.print("T�m say�lar =>  ");

		// T�m de�erler tek sat�rda yazd�l�r
		for (int i = 0; i < sizeOfHashTable; i++) {
			if(hashTable[i] != null) {
				binarySearchTree.inorderTraversalPrint(hashTable[i]);
			}
		}
		System.out.println();
	
	} 

}
