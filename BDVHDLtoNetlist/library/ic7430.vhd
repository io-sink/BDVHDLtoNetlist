library IEEE;
use IEEE.std_logic_1164.all; 

entity ic7430 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic7430 is "74xx";
	attribute component_name of ic7430 is "74HC30";
	attribute footprint_name of ic7430 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;
	attribute pin_type of VCC is "power_in";

	NC1 : in std_logic;
	attribute const_assign of NC1 is "open";
	attribute pin_assign of NC1 is 9;
	attribute pin_type of NC1 is "input";
	NC2 : in std_logic;
	attribute const_assign of NC2 is "open";
	attribute pin_assign of NC2 is 10;
	attribute pin_type of NC2 is "input";
	NC3 : in std_logic;
	attribute const_assign of NC3 is "open";
	attribute pin_assign of NC3 is 13;
	attribute pin_type of NC3 is "input";

	A : in std_logic;
	attribute pin_assign of A is 1;
	attribute pin_type of A is "input";
	B : in std_logic;
	attribute pin_assign of B is 2;
	attribute pin_type of B is "input";
	C : in std_logic;
	attribute pin_assign of C is 3;
	attribute pin_type of C is "input";
	D : in std_logic;
	attribute pin_assign of D is 4;
	attribute pin_type of D is "input";
	E : in std_logic;
	attribute pin_assign of E is 5;
	attribute pin_type of E is "input";
	F : in std_logic;
	attribute pin_assign of F is 6;
	attribute pin_type of F is "input";
	G : in std_logic;
	attribute pin_assign of G is 11;
	attribute pin_type of G is "input";
	H : in std_logic;
	attribute pin_assign of H is 12;
	attribute pin_type of H is "input";
	Y : out std_logic;
	attribute pin_assign of Y is 8;
	attribute pin_type of Y is "output"
	);
	end ic7430;

architecture logic of ic7430 is 
begin 

	Y <= not(A and B and C and D and E and F and G and H);

end logic;