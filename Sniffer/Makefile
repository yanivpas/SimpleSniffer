LDFLAGS = -lpcap 
CFLAGS = -Wall -pedantic -g
CC = gcc

simple_sniffer: sniffer_example.c packet_parser.c
	@echo $^
	$(CC) $(CFLAGS) $(LDFLAGS) -o $@ $^
	
