library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74126 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74126 is "74xx";
	attribute component_name of ic74126 is "74HC126";
	attribute footprint_name of ic74126 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;
	attribute pin_type of VCC is "power_in";

	A1 : in std_logic;
	attribute pin_assign of A1 is 2;
	attribute pin_type of A1 is "input";
	A2 : in std_logic;
	attribute pin_assign of A2 is 5;
	attribute pin_type of A2 is "input";
	A3 : in std_logic;
	attribute pin_assign of A3 is 9;
	attribute pin_type of A3 is "input";
	A4 : in std_logic;
	attribute pin_assign of A4 is 12;
	attribute pin_type of A4 is "input";

	G1 : in std_logic;
	attribute pin_assign of G1 is 1;
	attribute pin_type of G1 is "input";
	G2 : in std_logic;
	attribute pin_assign of G2 is 4;
	attribute pin_type of G2 is "input";
	G3 : in std_logic;
	attribute pin_assign of G3 is 10;
	attribute pin_type of G3 is "input";
	G4 : in std_logic;
	attribute pin_assign of G4 is 13;
	attribute pin_type of G4 is "input";

  Y1 : out std_logic;
  attribute pin_assign of Y1 is 3;
  attribute pin_type of Y1 is "output";
  Y2 : out std_logic;
  attribute pin_assign of Y2 is 6;
  attribute pin_type of Y2 is "output";
  Y3 : out std_logic;
  attribute pin_assign of Y3 is 8;
  attribute pin_type of Y3 is "output";
  Y4 : out std_logic;
  attribute pin_assign of Y4 is 11;
  attribute pin_type of Y4 is "output"
	);
	end ic74126;

architecture logic of ic74126 is 
  component triBuffer
    port (
      A : in std_logic;
      G : in std_logic;
      Y : out std_logic
    );
  end component;
begin 

  buf1 : triBuffer
  port map (
    A => A1, 
    G => G1, 
    Y => Y1
  );

  buf2 : triBuffer
  port map (
    A => A2, 
    G => G2, 
    Y => Y2
  );
  
  buf3 : triBuffer
  port map (
    A => A3, 
    G => G3, 
    Y => Y3
  );
  
  buf4 : triBuffer
  port map (
    A => A4, 
    G => G4, 
    Y => Y4
  );

end logic;