library IEEE;
use IEEE.std_logic_1164.all; 

entity 7430ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7430ic is "74xx";
	attribute component_name of 7430ic is "74HC30";
	attribute footprint_name of 7430ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;

	A : in std_logic;
	attribute pin_assign of A is 1;
	B : in std_logic;
	attribute pin_assign of B is 2;
	C : in std_logic;
	attribute pin_assign of C is 3;
	D : in std_logic;
	attribute pin_assign of D is 4;
	E : in std_logic;
	attribute pin_assign of E is 5;
	F : in std_logic;
	attribute pin_assign of F is 6;
	G : in std_logic;
	attribute pin_assign of G is 11;
	H : in std_logic;
	attribute pin_assign of H is 12;
	Y : out std_logic;
	attribute pin_assign of Y is 3
	);
	end 7430ic;

architecture logic of 7430ic is 
begin 

	Y <= not(A and B and C and D and E and F and G and H);

end logic;